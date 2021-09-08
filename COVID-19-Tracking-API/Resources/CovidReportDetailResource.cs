using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    public class CovidReportDetailResource  
    {
        public CovidDataByRegionResource CovidReport { get; set; }

        public List<CovidDataByDayRegionResource> CovidReportByDay { get; set; }

        public TotalVaccineDataResource VaccineReport { get; set; } 
    }
}
