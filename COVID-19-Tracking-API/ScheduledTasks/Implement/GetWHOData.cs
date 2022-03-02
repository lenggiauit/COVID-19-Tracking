using C19Tracking.API.Domain.Helpers;
using C19Tracking.API.Infrastructure;
using C19Tracking.Domain.Helpers;
using C19Tracking.Infrastructure;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Implement
{
    public class GetWHOData : ITaskBuilder
    {
        private readonly ILogger<GetWHOData> _logger;
        private readonly IC19TrackingHttpClientFactory _c19TrackingHttpClientFactory;
        private readonly IDistributedCache _distributedCache;
        private readonly APIDataSettings _APIDataSettings;
        public GetWHOData(ILogger<GetWHOData> logger, IC19TrackingHttpClientFactory c19TrackingHttpClientFactory, IDistributedCache distributedCache, IOptions<APIDataSettings> apiDataSettings)
        {
            _logger = logger;
            _c19TrackingHttpClientFactory = c19TrackingHttpClientFactory;
            _distributedCache = distributedCache;
            _APIDataSettings = apiDataSettings.Value;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("GetWHOData Task running!");
             
            foreach (var api in _APIDataSettings.ListAPIOptions)
            {
                JObject data = await _c19TrackingHttpClientFactory.SendAsync(api.Name, null);
                if (data != null)
                {
                    foreach (var node in api.NodeNames)
                    {
                        if (data.SelectToken(node) != null)
                        {
                            await _distributedCache.SetStringAsync(node, data.SelectToken(node).ToString());
                        }
                    }
                    if (data.SelectToken(api.StaticQueryNode) != null)
                    {

                        foreach (var p in data.SelectToken(api.StaticQueryNode))
                        {
                            JObject dataQuery = await _c19TrackingHttpClientFactory.SendUrlAsync(string.Format(api.StaticQueryUrl, p), null);
                            if (dataQuery != null)
                            {
                                foreach (var node in api.NodeNames)
                                {
                                    if (dataQuery.SelectToken(node) != null)
                                    {
                                        await _distributedCache.SetStringAsync(node, dataQuery.SelectToken(node).ToString());
                                    }
                                }
                            }
                        }

                    }
                }
            }
            _logger.LogInformation("GetWHOData Task is completed !");
            return await Task.FromResult(true); 
        }
    }
}
