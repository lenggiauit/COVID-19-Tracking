using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Converters
{
    public class DayGroupsConverter : IConverter
    {
        private dynamic _jsonObject;
        public DayGroupsConverter(dynamic jsonObject)
        {
            _jsonObject = jsonObject;
        }
        public string Convert()
        {
            if (_jsonObject != null)
            {
                List<CovidDataByDayGroup> covidDataByDayGroups = new List<CovidDataByDayGroup>();

                foreach (var dayGroup in _jsonObject)
                { 
                    DateTime dateReport = dayGroup["value"];  
                    foreach (var item in dayGroup["data"]["rows"])
                    { 
                        CovidDataByDayGroup covid19Data = new CovidDataByDayGroup();
                        covid19Data.ReportDate = dateReport;
                        covid19Data.CountryCode = item[0];
                        covid19Data.RegionCode = item[1];
                        covid19Data.Deaths = item[2] != null ? item[2] : 0;
                        covid19Data.Cumulative_Deaths = item[3] != null ? item[3] : 0;
                        covid19Data.Deaths_Last_7_Days = item[4] != null ? item[4] : 0;
                        covid19Data.Deaths_Last_7_Days_Change = item[5] != null ? item[5] : 0;
                        covid19Data.Deaths_Per_Hundred_Thousand = item[6] != null ? item[6] : 0;
                        covid19Data.Confirmed = item[7] != null ? item[7] : 0;
                        covid19Data.Cumulative_Confirmed = item[8] != null ? item[8] : 0;
                        covid19Data.Cases_Last_7_Days = item[9] != null ? item[9] : 0;
                        covid19Data.Cases_Last_7_Days_Change = item[10] != null ? item[10] : 0;
                        covid19Data.Cases_Per_Hundred_Thousand = item[11] != null ? item[11] : 0;
                        covid19Data.WkCasePop = item[12] != null ? item[12] : 0;
                        covid19Data.WkDeathPop = item[13] != null ? item[13] : 0;
                        covid19Data.Avg7Case = item[14] != null ? item[14] : 0;
                        covid19Data.Avg7Death = item[15] != null ? item[15] : 0;
                        covid19Data.Avg7CasePop = item[16] != null ? item[16] : 0;
                        covid19Data.Avg7DeathPop = item[17] != null ? item[17] : 0;
                        covidDataByDayGroups.Add(covid19Data);
                    }
                      
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
