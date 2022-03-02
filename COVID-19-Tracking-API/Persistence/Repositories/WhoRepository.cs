using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.API.Extensions;
using C19Tracking.API.Infrastructure;
using C19Tracking.API.Persistence.Contexts;
using C19Tracking.API.Persistence.Repositories;
using C19Tracking.Domain.Helpers;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.Domain.Services.Communication.Request;
using C19Tracking.ScheduledTasks.Converters;
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

namespace C19Tracking.Persistence.Repositories
{
    public class WhoRepository : BaseRepository, IWhoRepository
    {
        private readonly ILogger<WhoRepository> _logger;
        private readonly IDistributedCache _distributedCache;
        private readonly IC19TrackingHttpClientFactory _c19TrackingHttpClientFactory; 
        private readonly APIDataSettings _APIDataSettings;
        public WhoRepository(C19TrackingContext context, ILogger<WhoRepository> logger, IC19TrackingHttpClientFactory c19TrackingHttpClientFactory, IDistributedCache distributedCache, IOptions<APIDataSettings> apiDataSettings) : base(context) {
           
            _logger = logger;
            _c19TrackingHttpClientFactory = c19TrackingHttpClientFactory;
            _distributedCache = distributedCache;
            _APIDataSettings = apiDataSettings.Value;
        }
        /// <summary>
        /// Get case by region code
        /// </summary>
        /// <param name="regionCode"></param>
        /// <returns></returns>

        public async Task<CovidDataByRegion> GetCaseByRegion(string regionCode)
        { 
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.ByRegion.ToString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                List<CovidDataByRegion> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(jsonString);
                return covid19DataList.Where(l => l.RegionCode.Equals(regionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} is empty!");
                return null;
            }
        }

        public async Task<CovidReportDetail> GetDetailByRegion(BaseRequest<CovidReportDetailRequest> request)
        {
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.RegionWeekly.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonString))
            {

                CovidReportDetail covidReportDetail = new CovidReportDetail();

                JObject data = JObject.Parse(jsonString);

                

                foreach (KeyValuePair<string, JToken> item in data)
                {
                    CovidDataByDayRegion covid19Data = new CovidDataByDayRegion();
                    covid19Data.ReportDate = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(item.Key)).DateTime;
                    JToken jToken = item.Value;
                    foreach (JToken j in jToken.Children())
                    {
                        //string a1 = j.SelectToken("")[request.Payload.RegionCode.ToUpper()].ToString();
                    }
                }




                return covidReportDetail;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} is empty!");
                return null;
            }



            //string jsonStringCountryDetail = await _distributedCache.GetStringAsync(CacheKeys.CountryMapData.ToDescriptionString());
            //if (!string.IsNullOrEmpty(jsonStringCountryDetail))
            //{
            //    List<CovidDataByRegion> covidReportByDayList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(jsonStringCountryDetail);
            //    covidReportByDayList = covidReportByDayList.Where(l => l.WHO_REGION.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase)).ToList();
            //    CovidReportDetail covidReportDetail = new CovidReportDetail();
            //    List<CovidDataByRegion> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(jsonStringCountryDetail);
            //    // covidReportDetail. = covid19DataList;

            //    return null;

            //}
            //else
            //{
            //    _logger.LogWarning($"Cache {CacheKeys.ByRegion} is empty!");
            //    return null;
            //}



            //string covidbyRegionJson = await _distributedCache.GetStringAsync(CacheKeys.ByRegion.ToString());
            //string vaccineJson = await _distributedCache.GetStringAsync(CacheKeys.VaccineData.ToString());
            //string covidbyDayGroupJson = await _distributedCache.GetStringAsync(CacheKeys.DayGroups.ToString());

            //if (!string.IsNullOrEmpty(covidbyRegionJson) && !string.IsNullOrEmpty(vaccineJson) && !string.IsNullOrEmpty(covidbyDayGroupJson))
            //{
            //    CovidReportDetail covidReportDetail = new CovidReportDetail();
            //    List<CovidDataByRegion> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(covidbyRegionJson);
            //    // covidReportDetail.CovidReport = covid19DataList.Where(l => l.RegionCode.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            //    List<VaccineData> vaccineDataList = JsonConvert.DeserializeObject<List<VaccineData>>(vaccineJson);

            //    List<VaccineData> vaccineDataListByRegion = vaccineDataList.Where(l => l.RegionCode.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase)).ToList();

            //    VaccineData totalVaccineDatabyRegion = new VaccineData();
            //    foreach (var item in vaccineDataListByRegion)
            //    {
            //        totalVaccineDatabyRegion.PersonFullyVaccinated += item.PersonFullyVaccinated;
            //        totalVaccineDatabyRegion.PersonVaccinated1PlusDose += item.PersonVaccinated1PlusDose;
            //        totalVaccineDatabyRegion.VaccinesUsed = ReplaceString(totalVaccineDatabyRegion.VaccinesUsed, item.VaccinesUsed);
            //        totalVaccineDatabyRegion.TotalVaccinations += item.TotalVaccinations;
            //    }

            //    covidReportDetail.VaccineReport = totalVaccineDatabyRegion;

            //    List<CovidDataByDayGroup> covidDataByDayGroupList = JsonConvert.DeserializeObject<List<CovidDataByDayGroup>>(covidbyDayGroupJson);

            //    var filter = covidDataByDayGroupList
            //   .Where(l => l.ReportDate >= request.Payload.StartDate
            //     && l.RegionCode.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase))
            //   .ToList();

            //    covidReportDetail.CovidReportByDay = filter.GroupBy(l => l.ReportDate)
            //             .Select(lg =>
            //                   new CovidDataByDayRegion
            //                   {
            //                       ReportDate = lg.First().ReportDate,
            //                       TotalDeaths = lg.Sum(w => w.Deaths),
            //                       TotalConfirmed = lg.Sum(w => w.Confirmed),
            //                   }).ToList();

            //    return covidReportDetail;
            //}
            //else
            //{
            //    _logger.LogWarning($"Cache {CacheKeys.ByRegion} or {CacheKeys.VaccineData}  or {CacheKeys.DayGroups} is empty!");
            //    return null;
            //}
        }

        private string ReplaceString(string listString,string newStrings)
        {
            if (!string.IsNullOrEmpty(listString))
            {
                foreach (var str in newStrings.Split(','))
                {
                    if (listString.IndexOf(str) == -1)
                    {
                        listString += ", " + str;
                    }

                }
            }
            else
            {
                listString = newStrings;
            }
            return listString;
        }

        public async Task<List<CovidDataByRegion>> GetListCaseByRegion()
        {
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.ByRegion.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                List<CovidDataByRegion> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(jsonString);
                return covid19DataList;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} is empty!");
                return null;
            }
        }

        /// <summary>
        /// Get total case covid from cache
        /// </summary>
        /// <returns></returns>
        public async Task<Covid19Data> GetTotals()
        { 
            string jsonString =  await _distributedCache.GetStringAsync(CacheKeys.Totals.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonString))
            { 

                Covid19Data covid19Data = JsonConvert.DeserializeObject<Covid19Data>(jsonString);

                string jsonTodayString = await _distributedCache.GetStringAsync(CacheKeys.Today.ToDescriptionString());
                 
                string jsonLastUpdateString = await _distributedCache.GetStringAsync(CacheKeys.LastUpdate.ToDescriptionString());
                if (!string.IsNullOrEmpty(jsonLastUpdateString))
                {
                    covid19Data.UpdatedDate = DateTime.Parse(jsonLastUpdateString);
                }
                else
                {
                    covid19Data.UpdatedDate = DateTime.Now;
                }

                if (!string.IsNullOrEmpty(jsonTodayString))
                {
                    TodayData data = JsonConvert.DeserializeObject<TodayData>(jsonTodayString);
                    covid19Data.TodayConfirmed = data.Confirmed;
                    covid19Data.TodayDeaths = data.Deaths;
                }
                return covid19Data;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.Totals} is empty!");
                return null;
            } 
        }
         

        public async Task<CovidReportDetail> GetDetailByCountry(BaseRequest<DetailByCountryRequest> request)
        {
            string countryDetailByDateCacheKey = string.Format("country_detail_by_date_{0}", request.Payload.CountryCode);
            string countryDetailTodayCacheKey = string.Format("country_detail_Today_{0}", request.Payload.CountryCode);
            string jsonString = await _distributedCache.GetStringAsync(countryDetailByDateCacheKey);
            if (string.IsNullOrEmpty(jsonString))
            {
                string region = "";
                foreach (var r in _APIDataSettings.Regions)
                {
                    if (r.Countries.Contains(request.Payload.CountryCode, StringComparison.OrdinalIgnoreCase))
                    {
                        region = r.Name.ToLower();
                        break;
                    }
                }

                JObject data = await _c19TrackingHttpClientFactory.SendUrlAsync(string.Format(_APIDataSettings.DetailUrl, region, request.Payload.CountryCode.ToLower()) , null);
                if (data != null)
                {
                    CountryDetailConverter countryDetailConverter = new CountryDetailConverter(data);
                    string jsonData = countryDetailConverter.Convert();
                    await _distributedCache.SetStringAsync(countryDetailByDateCacheKey, jsonData);

                    CountryDetailTodayConverter countryDetailTodayConverter = new CountryDetailTodayConverter(data);
                    string jsonTodayData = countryDetailTodayConverter.Convert();
                    await _distributedCache.SetStringAsync(countryDetailTodayCacheKey, jsonTodayData);

                } 
            }
            else if (jsonString.Equals("CannotGet"))
            {
                _logger.LogWarning($"Cache {CacheKeys.CountryMapData} is empty!");
                return null;
            }
             
           
            CovidReportDetail covidReportDetail = new CovidReportDetail(); 
            string jsonStringReportDate = await _distributedCache.GetStringAsync(countryDetailByDateCacheKey);
            if (!string.IsNullOrEmpty(jsonStringReportDate))
            {
                List<CovidDataByDayRegion> covidReportByDayList = JsonConvert.DeserializeObject<List<CovidDataByDayRegion>>(jsonStringReportDate);
                covidReportDetail.CovidReportByDay = covidReportByDayList.Where(l => l.ReportDate >= request.Payload.StartDate)
               .ToList();
            }
            string jsonStringCountryDetail = await _distributedCache.GetStringAsync(CacheKeys.CountryMapData.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonStringCountryDetail))
            {
                List<CovidDataByRegion> covidReportByDayList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(jsonStringCountryDetail);
                covidReportDetail.CovidReport = covidReportByDayList.Where(l => l.CountryCode.Equals(request.Payload.CountryCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            string jsonStringTodayData = await _distributedCache.GetStringAsync(countryDetailTodayCacheKey);

            if (!string.IsNullOrEmpty(jsonStringTodayData))
            {
                TodayData todayData = JsonConvert.DeserializeObject<TodayData>(jsonStringTodayData);
                covidReportDetail.Today = todayData; 
            }

            return covidReportDetail;
           


            
        }

        public async Task<CovidDataByCountry> GetTotalCaseByCountry(BaseRequest<DetailByCountryRequest> request)
        {
            string covidbyCountryJson = await _distributedCache.GetStringAsync(CacheKeys.ByCountry.ToString());

            if (!string.IsNullOrEmpty(covidbyCountryJson))
            {
                List<CovidDataByCountry> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByCountry>>(covidbyCountryJson);
                return covid19DataList.Where(c => c.CountryCode.Equals(request.Payload.CountryCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} or {CacheKeys.VaccineData}  or {CacheKeys.DayGroups} is empty!");
                return null;
            }
        }

        public async Task<List<CovidDataByRegion>> GetCountryByRegion(BaseRequest<CovidReportDetailRequest> request)
        {
            string jsonStringCountryDetail = await _distributedCache.GetStringAsync(CacheKeys.CountryMapData.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonStringCountryDetail))
            {
                List<CovidDataByRegion> covidReport = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(jsonStringCountryDetail);
                List<CovidDataByRegion> covidReportFilter = new List<CovidDataByRegion>();
                string countries =  _APIDataSettings.Regions.Where(r => r.Name.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.Countries;
                foreach (var c in covidReport)
                {
                    if(countries.Split(',').Any( cc => cc.Equals( c.CountryCode, StringComparison.OrdinalIgnoreCase )))
                    {
                        covidReportFilter.Add(c);
                    }
                }

                return covidReportFilter;

            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} is empty!");
                return null;
            }




            //string covidbyRegionJson = await _distributedCache.GetStringAsync(CacheKeys.CountryGroups.ToString());

            //if (!string.IsNullOrEmpty(covidbyRegionJson))
            //{
            //    List<CovidDataByRegion> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(covidbyRegionJson);
            //    return covid19DataList.Where(c => c.RegionCode.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase)).ToList();
            //}
            //else
            //{
            //    _logger.LogWarning($"Cache {CacheKeys.CountryGroups} is empty!");
            //    return null;
            //}
        }

        public async Task<List<CovidDataByCountry>> GetTopByCountry()
        {
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.CountryMapData.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                List<CovidDataByCountry> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByCountry>>(jsonString);
                return covid19DataList.OrderByDescending(x => x.Cumulative_Confirmed).Take(10).ToList();
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.CountryMapData} is empty!");
                return null;
            }
        }

        public async Task<List<DeathsCountry>> GetTopDeathsByCountry()
        {
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.TopDeathsCountry.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                List<DeathsCountry> covid19DataList = JsonConvert.DeserializeObject<List<DeathsCountry>>(jsonString);
                return covid19DataList;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.TopDeathsCountry} is empty!");
                return null;
            }
        }

        public async Task<List<CasesCountry>> GetTopCasesByCountry()
        {
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.TopCasesCountry.ToDescriptionString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                List<CasesCountry> covid19DataList = JsonConvert.DeserializeObject<List<CasesCountry>>(jsonString);
                return covid19DataList;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.TopCasesCountry} is empty!");
                return null;
            }
        }

       
    }
}
