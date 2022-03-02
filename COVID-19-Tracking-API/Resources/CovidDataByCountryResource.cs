using AutoMapper;
using AutoMapper.Configuration.Annotations;
using C19Tracking.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    public class CovidDataByCountryResource : BaseResource
    {
        public string CountryCode { get; set; }
        public LatestMeasures LatestMeasures { get; set; }
    }

    [AutoMap(typeof(CasesCountry))]
    public class CasesCountryResource 
    {
        public string CountryCode { get; set; }
        public decimal Confirmed { get; set; }
        [SourceMember("Cumulative_Confirmed")]
        public decimal CumulativeConfirmed { get; set; }
    }

    [AutoMap(typeof(DeathsCountry))]
    public class DeathsCountryResource 
    {
        public string CountryCode { get; set; }
        public decimal Deaths { get; set; }
        [SourceMember("Cumulative_Deaths")]
        public decimal CumulativeDeaths { get; set; }
    }

}
