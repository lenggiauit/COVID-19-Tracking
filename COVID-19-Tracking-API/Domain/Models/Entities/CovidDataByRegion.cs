using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class CovidDataByRegion : Covid19Data
    {
        [JsonProperty("Country")]
        public string CountryCode { get; set; }
        [JsonProperty("Region")]
        public string RegionCode { get; set; }
        [JsonProperty("WHO_REGION")]
        public string WHO_REGION { get; set; }
        [JsonProperty("Latest Measures")]
        public LatestMeasures LatestMeasures { get; set; }
    }
}
