using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging; 

namespace C19Tracking.API.Persistence.Contexts
{
    public abstract class BaseContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public BaseContext(): base()
        { 
        }
        string GetConnectionString()
        {
            string connStr = string.Empty;
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            connStr = root.GetConnectionString("DefaultConnection");
            return connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  
            .EnableSensitiveDataLogging()
            .UseSqlServer(GetConnectionString());
        }
    }
}
