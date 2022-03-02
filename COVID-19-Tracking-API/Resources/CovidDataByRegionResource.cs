using C19Tracking.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    public class CovidDataByRegionResource : CaseByRegionResource
    {
        public LatestMeasures LatestMeasures { get; set; }
    }

    public class TodayDataResource
    {
        public decimal Deaths { get; set; }
        public decimal Confirmed { get; set; }
    }

}
