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
    public class GetWHOData : ITaskBuilder
    { 
        private readonly ILogger<GetWHOData> _logger; 
        private readonly IC19TrackingHttpClientFactory _c19TrackingHttpClientFactory;
        public GetWHOData(ILogger<GetWHOData> logger,  IC19TrackingHttpClientFactory c19TrackingHttpClientFactory)
        {
            _logger = logger;
            _c19TrackingHttpClientFactory = c19TrackingHttpClientFactory;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("GetWHOData Task running");







            return await Task.FromResult(true);
        }
    }
}
