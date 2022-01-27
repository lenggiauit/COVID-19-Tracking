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
        public GetWHOData(ILogger<GetWHOData> logger,  IC19TrackingHttpClientFactory c19TrackingHttpClientFactory, IDistributedCache distributedCache)
        {
            _logger = logger;
            _c19TrackingHttpClientFactory = c19TrackingHttpClientFactory;
            _distributedCache = distributedCache;
        }
        public async Task<bool> Invoke(ILogger logger)
        {
            _logger.LogInformation("GetWHOData Task running!");
            JObject jData = await _c19TrackingHttpClientFactory.SendAsync(Constants.WHOPageDataKey, null);
            if (jData != null)
            {
                var rawData = jData["result"]["pageContext"]["rawDataSets"];
                await _distributedCache.SetStringAsync(CacheRawKeys.ByDayRaw.ToString(), rawData["byDay"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.ByDayCumulativeRaw.ToString(), rawData["byDayCumulative"].ToString() );
                
                var buffer = new StringWriter(); 
                rawData["dayGroups"].WriteTo(new JsonTextWriter(buffer));
 
                await _distributedCache.SetStringAsync(CacheRawKeys.DayGroupsRaw.ToString(), buffer.ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.CountriesDailyChangeRaw.ToString(), rawData["countriesDailyChange"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.ByCountryRaw.ToString(), rawData["byCountry"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.CountryGroupsRaw.ToString(), rawData["countryGroups"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.TopCountryGroupsRaw.ToString(), rawData["topCountryGroups"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.ByRegionRaw.ToString(), rawData["byRegion"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.RegionGroupsRaw.ToString(), rawData["regionGroups"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.TodayRaw.ToString(), rawData["today"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.YesterdayRaw.ToString(), rawData["yesterday"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.StartDateRaw.ToString(), rawData["startDate"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.EndDateRaw.ToString(), rawData["endDate"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.LastUpdateRaw.ToString(), rawData["lastUpdate"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.LastDayPerCountryRaw.ToString(), rawData["lastDayPerCountry"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.Last7DaysPerCountryRaw.ToString(), rawData["last7DaysPerCountry"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.TotalsRaw.ToString(), rawData["totals"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.CreatedTimeRaw.ToString(), rawData["createdTime"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.CountriesCurrentRaw.ToString(), rawData["countriesCurrent"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.VaccineDataRaw.ToString(), rawData["vaccineData"].ToString());
                await _distributedCache.SetStringAsync(CacheRawKeys.VaccineMetaDataRaw.ToString(), rawData["vaccineMetaData"].ToString());
                _logger.LogInformation("GetWHOData Task is completed !");
                return await Task.FromResult(true);
            }
            else
            {
                _logger.LogError($"GetWHOData Task was failed: Can't get data from WHO!");
                return await Task.FromResult(false);
            }  
        }
    }
}
