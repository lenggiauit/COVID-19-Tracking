using C19Tracking.Domain.Helpers;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Implement
{
    public class SaveToCache : ITaskBuilder
    {
        private readonly ILogger<SaveToCache> _logger;
        private readonly APIDataSettings _apiDataSettings;
        public SaveToCache(ILogger<SaveToCache> logger,
            IOptions<APIDataSettings> apiDataSettings)
        {
            _logger = logger;
            _apiDataSettings = apiDataSettings.Value;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("SaveToCache Task running");
            return await Task.FromResult(true); 
        }
    }
}
