using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Converters
{
    public class TotalsConverter : IConverter
    {
        private dynamic _jsonObject;
        public TotalsConverter(dynamic jsonObject)
        {
            _jsonObject = jsonObject;
        }
       
        public string Convert()
        {
            if (_jsonObject != null)
            {
                Covid19Data covid19Data = new Covid19Data();
                covid19Data.Deaths = _jsonObject["Deaths"];
                covid19Data.CumulativeDeaths = _jsonObject["Cumulative Deaths"];
                covid19Data.DeathsLast7Days = _jsonObject["Deaths Last 7 Days"];
                covid19Data.DeathsLast7DaysChange = _jsonObject["Deaths Last 7 Days Change"];
                covid19Data.DeathsPerHundredThousand = _jsonObject["Deaths Per Hundred Thousand"];
                covid19Data.Confirmed = _jsonObject["Confirmed"];
                covid19Data.CumulativeConfirmed = _jsonObject["Cumulative Confirmed"];
                covid19Data.CasesLast7Days = _jsonObject["Cases Last 7 Days"];
                covid19Data.CasesLast7DaysChange = _jsonObject["Cases Last 7 Days Change"];
                covid19Data.CasesPerHundredThousand = _jsonObject["Cases Per Hundred Thousand"];
                covid19Data.WkCasePop = _jsonObject["WkCasePop"];
                covid19Data.WkDeathPop = _jsonObject["WkDeathPop"];
                covid19Data.Avg7Case = _jsonObject["Avg7Case"];
                covid19Data.Avg7Death = _jsonObject["Avg7Death"];
                covid19Data.Avg7CasePop = _jsonObject["Avg7CasePop"];
                covid19Data.Avg7DeathPop = _jsonObject["Avg7DeathPop"];  
                return JsonConvert.SerializeObject(covid19Data);
            }
            else
            { 
                return string.Empty;
            }
        }
    }
}
