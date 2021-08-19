using C19Tracking.API.Infrastructure;
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
    public class CleanUpRawData : ITaskBuilder
    {
        private readonly ILogger<CleanUpRawData> _logger;
        private readonly APIDataSettings _apiDataSettings;
        private readonly IDistributedCache _distributedCache;
        public CleanUpRawData(ILogger<CleanUpRawData> logger,
            IOptions<APIDataSettings> apiDataSettings, IDistributedCache distributedCache)
        {
            _logger = logger;
            _apiDataSettings = apiDataSettings.Value;
            _distributedCache = distributedCache;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("Clean Up Raw Data Task running !");
            try
            {
                foreach (CacheRawKeys cacheKey in Enum.GetValues(typeof(CacheRawKeys)))
                {
                    await _distributedCache.RemoveAsync(cacheKey.ToString());
                }
                _logger.LogInformation("Clean Up Raw Data Task completed !");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Clean Up Raw Data Task was failed: {ex.Message}");
            } 
            return await Task.FromResult(true);
        }
    }
}
