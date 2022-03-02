using C19Tracking.API.Extensions;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Converters
{
    public class CountryDetailConverter : IConverter
    {
        private dynamic _jsonObject;
        public CountryDetailConverter(dynamic jsonObject)
        {
            _jsonObject = jsonObject;
        }
        public string Convert()
        {
            try
            {
                if (_jsonObject != null)
                {
                    JObject data = JObject.Parse(_jsonObject["result"]["data"]["countryGroup"]["data"].Value);
                    List<CovidDataByDayRegion> list = new List<CovidDataByDayRegion>();
                    foreach (dynamic item in data["rows"])
                    {
                        CovidDataByDayRegion covid19Data = new CovidDataByDayRegion();
                        covid19Data.ReportDate = DateTimeOffset.FromUnixTimeMilliseconds((long)item[0]).DateTime;
                        covid19Data.TotalDeaths = item[2];
                        covid19Data.TotalConfirmed = item[7]; 
                        list.Add(covid19Data);
                    }
                    return JsonConvert.SerializeObject(list);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                
                return string.Empty;
            }
        }
    }


    public class CountryDetailTodayConverter : IConverter
    {
        private dynamic _jsonObject;
        public CountryDetailTodayConverter(dynamic jsonObject)
        {
            _jsonObject = jsonObject;
        }
        public string Convert()
        {
            try
            {
                if (_jsonObject != null)
                {
                    
                    TodayData todayData = new TodayData();
                    todayData.Deaths = _jsonObject["result"]["data"]["countryPageData"]["today"]["Deaths"];
                    todayData.Confirmed = _jsonObject["result"]["data"]["countryPageData"]["today"]["Confirmed"];
                    return JsonConvert.SerializeObject(todayData);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }
    }

}
