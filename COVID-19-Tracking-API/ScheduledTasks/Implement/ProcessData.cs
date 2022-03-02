using C19Tracking.API.Extensions;
using C19Tracking.API.Infrastructure;
using C19Tracking.Domain.Helpers;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Converters;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nancy.Json;
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
                    try
                    { 
                        string jsonString = await _distributedCache.GetStringAsync(ConvertCacheKey.GetRawKey(cacheKey).ToString());
                        if (!string.IsNullOrEmpty(jsonString))
                        {
                            switch (cacheKey)
                            {
                                case CacheKeys.Totals:
                                    {
                                        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                        TotalsConverter totalsConverter = new TotalsConverter(jsonObject); 
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), totalsConverter.Convert());
                                    }
                                    break;
                                case CacheKeys.Today:
                                case CacheKeys.Yesterday:
                                    {
                                        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                        TodayYesterdayConverter converter = new TodayYesterdayConverter(jsonObject);
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), converter.Convert());
                                    }
                                    break;
                                case CacheKeys.ByRegion:
                                    {
                                        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                        RegionConverter regionConverter = new RegionConverter(jsonObject);
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), regionConverter.Convert());
                                    }
                                    break;
                                case CacheKeys.LastUpdate:
                                    {
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), jsonString);
                                    }
                                    break;
                                case CacheKeys.VaccineData:
                                    {
                                        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                        VaccineDataConverter vaccineDataConverter = new VaccineDataConverter(jsonObject);
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), vaccineDataConverter.Convert());
                                    }
                                    break;
                                case CacheKeys.DayGroups:
                                    {
                                        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                        DayGroupsConverter dayGroupsConverter = new DayGroupsConverter(jsonObject);
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), dayGroupsConverter.Convert());
                                    }
                                    break;
                                //case CacheKeys.TopCountryGroups:
                                //    {
                                //        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                //        TopCountryGroupsConverter topCountryGroupsConverter = new TopCountryGroupsConverter(jsonObject);
                                //        await _distributedCache.SetStringAsync(cacheKey.ToString(), topCountryGroupsConverter.Convert());
                                //    }
                                //    break;
                                case CacheKeys.ByCountry:
                                    {
                                        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                        ByCountryConverter byCountryConverter = new ByCountryConverter(jsonObject);
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), byCountryConverter.Convert());
                                    }
                                    break;
                                case CacheKeys.CountryGroups:
                                    {
                                        var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
                                        CountryGroupsConverter countryGroupsConverter = new CountryGroupsConverter(jsonObject);
                                        await _distributedCache.SetStringAsync(cacheKey.ToString(), countryGroupsConverter.Convert());
                                    }
                                    break;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"ProcessData Task was failed: {ex.Message}");
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
