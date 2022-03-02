using AutoMapper;
using AutoMapper.Configuration.Annotations;
using C19Tracking.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    [AutoMap(typeof(Covid19Data))]
    public partial class BaseResource
    {
        public decimal TodayConfirmed { get; set; }
        public decimal TodayDeaths { get; set; }
        public decimal Deaths { get; set; }
        [SourceMember("Cumulative_Deaths")]
        public decimal CumulativeDeaths { get; set; }
        [SourceMember("Deaths_Last_7_Days")]
        public decimal DeathsLast7Days { get; set; }
        [SourceMember("Deaths_Last_7_Days_Change")]
        public decimal DeathsLast7DaysChange { get; set; }
        [SourceMember("Deaths_Per_Hundred_Thousand")]
        public decimal DeathsPerHundredThousand { get; set; }
        public decimal Confirmed { get; set; }
        [SourceMember("Cumulative_Confirmed")]
        public decimal CumulativeConfirmed { get; set; }
        [SourceMember("Cases_Last_7_Days")]
        public decimal CasesLast7Days { get; set; }
        [SourceMember("Cases_Last_7_Days_Change")]
        public decimal CasesLast7DaysChange { get; set; }
        [SourceMember("Cases_Per_Hundred_Thousand")]
        public decimal CasesPerHundredThousand { get; set; }
        public decimal WkCasePop { get; set; }
        public decimal WkDeathPop { get; set; }
        public decimal Avg7Case { get; set; }
        public decimal Avg7Death { get; set; }
        public decimal Avg7CasePop { get; set; }
        public decimal Avg7DeathPop { get; set; }
    }

    [AutoMap(typeof(CovidDataByCountry))]
    public partial class BaseResourceTop
    {
       
        public decimal Deaths { get; set; }
        [SourceMember("Cumulative_Deaths")]
        public decimal CumulativeDeaths { get; set; }
        [SourceMember("Deaths_Last_7_Days")]
        public decimal DeathsLast7Days { get; set; }
        [SourceMember("Deaths_Last_7_Days_Change")]
        public decimal DeathsLast7DaysChange { get; set; }
        [SourceMember("Deaths_Per_Hundred_Thousand")]
        public decimal DeathsPerHundredThousand { get; set; }
        public decimal Confirmed { get; set; }
        [SourceMember("Cumulative_Confirmed")]
        public decimal CumulativeConfirmed { get; set; }
        
    }


}
