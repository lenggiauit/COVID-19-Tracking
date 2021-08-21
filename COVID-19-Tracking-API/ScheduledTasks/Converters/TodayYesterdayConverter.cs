using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Converters
{
    public class TodayYesterdayConverter : IConverter
    {
        private dynamic _jsonObject;
        public TodayYesterdayConverter(dynamic jsonObject)
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
                covid19Data.Confirmed = _jsonObject["Confirmed"];
                covid19Data.CumulativeConfirmed = _jsonObject["Cumulative Confirmed"]; 
                return JsonConvert.SerializeObject(covid19Data);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
