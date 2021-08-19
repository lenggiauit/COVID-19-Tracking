using C19Tracking.API.Controllers.Config;
using C19Tracking.API.Domain.Helpers;
using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Domain.Services;
using C19Tracking.API.Extensions;
using C19Tracking.API.Infrastructure;
using C19Tracking.API.Persistence.Contexts;
using C19Tracking.API.Persistence.Repositories;
using C19Tracking.API.Services;
using C19Tracking.Domain.Helpers;
using C19Tracking.Infrastructure;
using C19Tracking.ScheduledTasks;
using C19Tracking.ScheduledTasks.Enums;
using C19Tracking.ScheduledTasks.Implement;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFactory = C19Tracking.ScheduledTasks.Implement.TaskFactory;

namespace C19Tracking.API
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DelayFilter));
            })
            .AddNewtonsoftJson();
            services.AddMemoryCache();

            services.AddCustomSwagger();
            services.AddControllers();
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                // Adds a custom error response factory when ModelState is invalid
                options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
            });
            services.AddCors();
            services.AddDbContext<C19TrackingContext>();
            services.AddAutoMapper(typeof(Startup));
            // Services
             
            services.AddTransient<ITaskFactory, TaskFactory>(); 

           // services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IC19TrackingHttpClientFactory, C19TrackingHttpClientFactory>();
             
            services.AddTransient<GetWHOData>();
            services.AddTransient<ProcessData>();
            services.AddTransient<CleanUpData>();
            services.AddTransient<SaveToCache>();
            services.AddTransient<TaskResolver>(serviceProvider => taskType =>
            {
                switch (taskType)
                {
                    case FlowTask.GetWHOData:
                        return serviceProvider.GetService<GetWHOData>();
                    case FlowTask.ProcessData:
                        return serviceProvider.GetService<ProcessData>();
                    case FlowTask.CleanUpData:
                        return serviceProvider.GetService<CleanUpData>();
                    case FlowTask.SaveToCache:
                        return serviceProvider.GetService<SaveToCache>();
                    default:
                        return null;
                }
            }); 

            //
            services.AddHostedService<ScheduledService>();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // Api Data Setting
            var apiSettingsSection = Configuration.GetSection("APIDataSettings");
            services.Configure<APIDataSettings>(apiSettingsSection);
            
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var accService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = accService.GetById(userId);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomSwagger(appSettings);

            app.UseStaticFiles();
            string fileFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles");
            if (!Directory.Exists(fileFolder))
                Directory.CreateDirectory(fileFolder);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles")),
                RequestPath = "/Files"
            });
            app.UseRouting();


            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}