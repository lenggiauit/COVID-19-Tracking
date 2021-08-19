using C19Tracking.API.Extensions;
using C19Tracking.API.Infrastructure;
using C19Tracking.Domain.Helpers;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace C19Tracking.ScheduledTasks.Implement
{
    public class ProcessData : ITaskBuilder
    {
        private readonly ILogger<ProcessData> _logger;
        private readonly IDistributedCache _distributedCache;
        private readonly APIDataSettings _apiDataSettings;
        public ProcessData(ILogger<ProcessData> logger,
            IOptions<APIDataSettings> apiDataSettings, IDistributedCache distributedCache)
        {
            _logger = logger;
            _apiDataSettings = apiDataSettings.Value;
            _distributedCache = distributedCache;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("ProcessData Task running"); 
            try
            {
                foreach (CacheKeys cacheKey in Enum.GetValues(typeof(CacheKeys)))
                {
                   string jsonString =  await _distributedCache.GetStringAsync(ConvertCacheKey.GetRawKey(cacheKey).ToString());
                   JObject jsonObj = JObject.Parse(jsonString);
                    switch (cacheKey)
                    {
                        case CacheKeys.Totals:
                        {
                            Covid19Data covid19Data = new Covid19Data();
                            covid19Data.Deaths = jsonObj["Deaths"].ToInt();



                            string jsonStringCoverted = JsonConvert.SerializeObject(covid19Data);
                            await _distributedCache.SetStringAsync(cacheKey.ToString(), jsonStringCoverted);
                        } 
                        break; 
                    } 
                } 
                return await Task.FromResult(true);
            }
            catch(Exception ex)
            {
                _logger.LogError($"ProcessData Task was failed: {ex.Message}");
                return await Task.FromResult(false);
            }

            
        }
    }
}
