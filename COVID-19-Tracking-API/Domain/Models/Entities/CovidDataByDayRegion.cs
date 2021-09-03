using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class CovidDataByDayRegion
    {
        public DateTime ReportDate { get; set; }
        public decimal TotalDeaths { get; set; } 
        public decimal TotalConfirmed { get; set; } 
    }
}
