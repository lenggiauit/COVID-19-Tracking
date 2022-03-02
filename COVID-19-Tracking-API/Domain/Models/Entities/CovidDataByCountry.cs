using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class CovidDataByCountry: Covid19Data
    {
        [JsonProperty("Country")]
        public string CountryCode { get; set; }
        [JsonProperty("Latest Measures")]
        public LatestMeasures LatestMeasures { get; set; }
    }


public class TotalsDeaths
{
    public decimal Deaths { get; set; }
    public decimal Cumulative_Deaths { get; set; }
}

public class TotalsCases
{
    public decimal Confirmed { get; set; }
    public decimal Cumulative_Confirmed { get; set; }
}

public class DeathsCountry
{
    [JsonProperty("ISO_2_CODE")]
    public string CountryCode { get; set; }

    [JsonProperty("totals")]
    public TotalsDeaths TotalsDeaths { get; set; }

    public decimal Deaths { get { return TotalsDeaths.Deaths; } }
    public decimal Cumulative_Deaths { get { return TotalsDeaths.Cumulative_Deaths; } }

}

public class CasesCountry
{
    [JsonProperty("ISO_2_CODE")]
    public string CountryCode { get; set; }

    [JsonProperty("totals")]
    public TotalsCases TotalsCases { get; set; }

    public decimal Confirmed { get { return TotalsCases.Confirmed; } }
    public decimal Cumulative_Confirmed { get { return TotalsCases.Cumulative_Confirmed; } }

}
}
