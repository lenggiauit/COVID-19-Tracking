using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class CovidDataByDayGroup : CovidDataByRegion
    {
        public DateTime ReportDate { get; set; } 
    }
}
