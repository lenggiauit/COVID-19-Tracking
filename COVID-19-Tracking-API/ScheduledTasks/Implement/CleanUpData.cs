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
    public class CleanUpData : ITaskBuilder
    {
        private readonly ILogger<CleanUpData> _logger;
        private readonly APIDataSettings _apiDataSettings;
        public CleanUpData(ILogger<CleanUpData> logger,
            IOptions<APIDataSettings> apiDataSettings)
        {
            _logger = logger;
            _apiDataSettings = apiDataSettings.Value;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("CleanUpData Task running"); 
            _logger.LogWarning("CleanUpData Task failed");

            return await Task.FromResult(true);
        }
    }
}
