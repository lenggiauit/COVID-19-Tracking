using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Converters
{
    public class RegionConverter : IConverter
    {
        private dynamic _jsonObject;
        public RegionConverter(dynamic jsonObject)
        {
            _jsonObject = jsonObject;
        }
        public string Convert()
        {
            if (_jsonObject != null)
            {
                List<CovidDataByRegion> list = new List<CovidDataByRegion>();
                foreach (var item in _jsonObject["rows"])
                {
                    CovidDataByRegion covid19Data = new CovidDataByRegion();
                    covid19Data.RegionCode = item[0];
                    covid19Data.Deaths = item[1];
                    covid19Data.CumulativeDeaths = item[2];
                    covid19Data.DeathsLast7Days = item[3];
                    covid19Data.DeathsLast7DaysChange = item[4];
                    covid19Data.DeathsPerHundredThousand = item[5];
                    covid19Data.Confirmed = item[6];
                    covid19Data.CumulativeConfirmed = item[7];
                    covid19Data.CasesLast7Days = item[8];
                    covid19Data.CasesLast7DaysChange = item[9];
                    covid19Data.CasesPerHundredThousand = item[10];
                    covid19Data.WkCasePop = item[11];
                    covid19Data.WkDeathPop = item[12];
                    covid19Data.Avg7Case = item[13];
                    covid19Data.Avg7Death = item[14];
                    covid19Data.Avg7CasePop = item[15];
                    covid19Data.Avg7DeathPop = item[16];
                    list.Add(covid19Data);
                } 
                return JsonConvert.SerializeObject(list);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
