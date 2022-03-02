using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace C19Tracking.ScheduledTasks.Converters
{
    public class TopCountryGroupsConverter : IConverter
    {
        private dynamic _jsonObject;
        public TopCountryGroupsConverter(dynamic jsonObject)
        {
            _jsonObject = jsonObject;
        }
        public string Convert()
        {
            if (_jsonObject != null)
            {
                List<CovidDataByTopCountryGroups> covidDataByDayGroups = new List<CovidDataByTopCountryGroups>();

                foreach (var topCountry in _jsonObject)
                {
                    string countryCode = topCountry["value"];
                    var item = topCountry["data"]["totals"]; 
                    CovidDataByTopCountryGroups covid19Data = new CovidDataByTopCountryGroups(); 
                    covid19Data.CountryCode = countryCode; 
                    covid19Data.Deaths = item[0] != null ? item[0] : 0;
                    covid19Data.Cumulative_Deaths = item[1] != null ? item[1] : 0;
                    covid19Data.Deaths_Last_7_Days = item[2] != null ? item[2] : 0;
                    covid19Data.Deaths_Last_7_Days_Change = item[3] != null ? item[3] : 0;
                    covid19Data.Deaths_Per_Hundred_Thousand = item[4] != null ? item[4] : 0;
                    covid19Data.Confirmed = item[5] != null ? item[5] : 0;
                    covid19Data.Cumulative_Confirmed = item[6] != null ? item[6] : 0;
                    covid19Data.Cases_Last_7_Days = item[7] != null ? item[7] : 0;
                    covid19Data.Cases_Last_7_Days_Change = item[8] != null ? item[8] : 0;
                    covid19Data.Cases_Per_Hundred_Thousand = item[9] != null ? item[9] : 0;
                    covid19Data.WkCasePop = item[10] != null ? item[10] : 0;
                    covid19Data.WkDeathPop = item[11] != null ? item[11] : 0;
                    covid19Data.Avg7Case = item[12] != null ? item[12] : 0;
                    covid19Data.Avg7Death = item[13] != null ? item[13] : 0;
                    covid19Data.Avg7CasePop = item[14] != null ? item[14] : 0;
                    covid19Data.Avg7DeathPop = item[15] != null ? item[15] : 0;
                    covidDataByDayGroups.Add(covid19Data); 
                } 
                return JsonConvert.SerializeObject(covidDataByDayGroups);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
