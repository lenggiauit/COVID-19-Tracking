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
using C19Tracking.Persistence.Repositories;
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
            // Use microsoft DistributedMemoryCache
            services.AddDistributedMemoryCache();
            // if you want to use Redis cache
            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = "[yourconnection string]";
            //    option.InstanceName = "[your instance name]";
            //});
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
           
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // Api Data Setting
            var apiSettingsSection = Configuration.GetSection("APIDataSettings");
            services.Configure<APIDataSettings>(apiSettingsSection); 
            services.AddTransient<ITaskFactory, TaskFactory>(); 
            services.AddTransient<IC19TrackingHttpClientFactory, C19TrackingHttpClientFactory>();
             
            services.AddTransient<GetWHOData>();
            services.AddTransient<ProcessData>();
            services.AddTransient<CleanUpRawData>();
            services.AddTransient<SaveToDatabase>();
            services.AddTransient<TaskResolver>(serviceProvider => taskType =>
            {
                switch (taskType)
                {
                    case FlowTask.GetWHOData:
                        return serviceProvider.GetService<GetWHOData>();
                    case FlowTask.ProcessData:
                        return serviceProvider.GetService<ProcessData>();
                    case FlowTask.CleanUpRawData:
                        return serviceProvider.GetService<CleanUpRawData>();
                    case FlowTask.SaveToDatabase:
                        return serviceProvider.GetService<SaveToDatabase>();
                    default:
                        return null;
                }
            }); 

            //
            services.AddHostedService<ScheduledService>();
            // services
            services.AddScoped<IWhoService, WhoService>();
            // Repositories
            services.AddScoped<IWhoRepository, WhoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddHttpClient();
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