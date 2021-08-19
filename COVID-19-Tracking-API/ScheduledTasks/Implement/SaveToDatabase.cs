using C19Tracking.Domain.Helpers;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Implement
{
    public class SaveToDatabase : ITaskBuilder
    {
        private readonly ILogger<SaveToDatabase> _logger;
        private readonly APIDataSettings _apiDataSettings;
        private readonly IDistributedCache _distributedCache;
        public SaveToDatabase(ILogger<SaveToDatabase> logger,
            IOptions<APIDataSettings> apiDataSettings, IDistributedCache distributedCache)
        {
            _logger = logger;
            _apiDataSettings = apiDataSettings.Value;
            _distributedCache = distributedCache;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("SaveToDatabase Task running");
            // Do to implement
            return await Task.FromResult(true); 
        }
    }
}
