using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    [Serializable]
    public class TodayData
    {
        public decimal Deaths { get; set; }
        public decimal Confirmed { get; set; }
    }
    [Serializable]
    public class LatestMeasures
    {
        [JsonProperty("MEASURES_IN_PLACE")]
        public string MeasuresInPlace { get; set; }
        [JsonProperty("MASKS__1")]
        public string Mask { get; set; }
        [JsonProperty("TRAVEL__1")]
        public string Travel { get; set; }
        [JsonProperty("GATHERINGS__1")]
        public string Gatherings { get; set; }
        [JsonProperty("SCHOOLS__1")]
        public string School { get; set; }
        [JsonProperty("BUSINESSES__1")]
        public string Businesses { get; set; }
        [JsonProperty("MOVEMENTS__1")]
        public string Movements { get; set; }

    }
    [Serializable]
    public class Covid19Data
    {
        public DateTime UpdatedDate { get; set; }
        public decimal TodayConfirmed { get; set; }
        public decimal TodayDeaths { get; set; }
        public decimal Deaths { get; set; }
        [JsonProperty("Cumulative Deaths")]
        public decimal Cumulative_Deaths { get; set; }
        [JsonProperty("Deaths Last 7 Days")]
        public decimal Deaths_Last_7_Days { get; set; }
        [JsonProperty("Deaths Last 7 Days Change")]
        public decimal Deaths_Last_7_Days_Change { get; set; }
        [JsonProperty("Deaths Per Hundred Thousand")]
        public decimal Deaths_Per_Hundred_Thousand { get; set; }
        public decimal Confirmed { get; set; }
        [JsonProperty("Cumulative Confirmed")]
        public decimal Cumulative_Confirmed { get; set; }
        [JsonProperty("Cases Last 7 Days")]
        public decimal Cases_Last_7_Days { get; set; }
        [JsonProperty("Cases Last 7 Days Change")]
        public decimal Cases_Last_7_Days_Change { get; set; }
        [JsonProperty("Cases Per Hundred Thousand")]
        public decimal Cases_Per_Hundred_Thousand { get; set; }
        public decimal WkCasePop { get; set; }
        public decimal WkDeathPop { get; set; }
        public decimal Avg7Case { get; set; }
        public decimal Avg7Death { get; set; }
        public decimal Avg7CasePop { get; set; }
        public decimal Avg7DeathPop { get; set; }
        

    }
}
