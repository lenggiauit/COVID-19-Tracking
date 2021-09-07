using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.API.Infrastructure;
using C19Tracking.API.Persistence.Contexts;
using C19Tracking.API.Persistence.Repositories;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.Domain.Services.Communication.Request;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public WhoRepository(C19TrackingContext context, ILogger<WhoRepository> logger, IDistributedCache distributedCache) : base(context) {
            _distributedCache = distributedCache;
            _logger = logger;
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
                return covid19DataList.Where( l => l.RegionCode.Equals(regionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} is empty!");
                return null;
            }
        }

        public async Task<CovidReportDetail> GetDetailByRegion(BaseRequest<CovidReportDetailRequest> request)
        { 
            string covidbyRegionJson = await _distributedCache.GetStringAsync(CacheKeys.ByRegion.ToString());
            string vaccineJson = await _distributedCache.GetStringAsync(CacheKeys.VaccineData.ToString());
            string covidbyDayGroupJson = await _distributedCache.GetStringAsync(CacheKeys.DayGroups.ToString());

            if (!string.IsNullOrEmpty(covidbyRegionJson) && !string.IsNullOrEmpty(vaccineJson) && !string.IsNullOrEmpty(covidbyDayGroupJson))
            {
                CovidReportDetail covidReportDetail = new CovidReportDetail();
                List<CovidDataByRegion> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByRegion>>(covidbyRegionJson);
                covidReportDetail.CovidReport = covid19DataList.Where(l => l.RegionCode.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                List<VaccineData> vaccineDataList = JsonConvert.DeserializeObject<List<VaccineData>>(vaccineJson);

                List<VaccineData> vaccineDataListByRegion = vaccineDataList.Where(l => l.RegionCode.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase)).ToList();

                VaccineData totalVaccineDatabyRegion = new VaccineData();
                foreach (var item in vaccineDataListByRegion)
                { 
                    totalVaccineDatabyRegion.PersonFullyVaccinated += item.PersonFullyVaccinated;
                    totalVaccineDatabyRegion.PersonVaccinated1PlusDose += item.PersonVaccinated1PlusDose; 
                    totalVaccineDatabyRegion.VaccinesUsed = ReplaceString(totalVaccineDatabyRegion.VaccinesUsed, item.VaccinesUsed );
                    totalVaccineDatabyRegion.TotalVaccinations += item.TotalVaccinations; 
                }  

                covidReportDetail.VaccineReport = totalVaccineDatabyRegion;

                List<CovidDataByDayGroup> covidDataByDayGroupList = JsonConvert.DeserializeObject<List<CovidDataByDayGroup>>(covidbyDayGroupJson);
                 
                var filter = covidDataByDayGroupList
               .Where(l => l.ReportDate >= request.Payload.StartDate
                 && l.RegionCode.Equals(request.Payload.RegionCode, StringComparison.OrdinalIgnoreCase))
               .ToList();
                 
                covidReportDetail.CovidReportByDayRegion = filter.GroupBy(l => l.ReportDate)
                         .Select(lg =>
                               new CovidDataByDayRegion
                               {
                                   ReportDate  = lg.First().ReportDate, 
                                   TotalDeaths = lg.Sum(w => w.Deaths), 
                                   TotalConfirmed = lg.Sum(w => w.Confirmed), 
                               }).ToList();
                 
                return covidReportDetail;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} or {CacheKeys.VaccineData}  or {CacheKeys.DayGroups} is empty!");
                return null;
            }
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
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.ByRegion.ToString());
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
            string jsonString =  await _distributedCache.GetStringAsync(CacheKeys.Totals.ToString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                string jsonUpdatedDate = await _distributedCache.GetStringAsync(CacheKeys.LastUpdate.ToString());
                Covid19Data covid19Data = JsonConvert.DeserializeObject<Covid19Data>(jsonString);
                covid19Data.UpdatedDate = DateTime.Parse(jsonUpdatedDate); 
                return covid19Data;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.Totals} is empty!");
                return null;
            } 
        }

        public async  Task<List<CovidDataByCountry>> GetTopByCountry()
        {
            string jsonString = await _distributedCache.GetStringAsync(CacheKeys.TopCountryGroups.ToString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                List<CovidDataByCountry> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByCountry>>(jsonString);
                return covid19DataList;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} is empty!");
                return null;
            }
        }

        public async Task<CovidDataByCountry> GetDetailByCountry(BaseRequest<DetailByCountryRequest> request)
        {
            string covidbyCountryJson = await _distributedCache.GetStringAsync(CacheKeys.ByCountry.ToString());
            
            if (!string.IsNullOrEmpty(covidbyCountryJson))
            { 
                List<CovidDataByCountry> covid19DataList = JsonConvert.DeserializeObject<List<CovidDataByCountry>>(covidbyCountryJson); 
                return covid19DataList.Where(c=> c.CountryCode.Equals(request.Payload.CountryCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.ByRegion} or {CacheKeys.VaccineData}  or {CacheKeys.DayGroups} is empty!");
                return null;
            }
        }
    }
}
