using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class CovidReportDetail
    {
        public CovidDataByRegion CovidReport { get; set; }
        public List<CovidDataByDayRegion> CovidReportByDay { get; set; } 
        public VaccineData VaccineReport { get; set; } 
    }
}
