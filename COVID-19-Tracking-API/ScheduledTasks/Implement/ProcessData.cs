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
    public class ProcessData : ITaskBuilder
    {
        private readonly ILogger<ProcessData> _logger;
        private readonly APIDataSettings _apiDataSettings;
        public ProcessData(ILogger<ProcessData> logger,
            IOptions<APIDataSettings> apiDataSettings)
        {
            _logger = logger;
            _apiDataSettings = apiDataSettings.Value;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("ProcessData Task running");
            return await Task.FromResult(true);
        }
    }
}
