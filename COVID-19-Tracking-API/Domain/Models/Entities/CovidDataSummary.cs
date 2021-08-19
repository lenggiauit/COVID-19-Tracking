using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class CovidDataSummary
    {
        public string Confirmed { get; set; }
        public string Cumulative { get; set; }
        public string Deaths { get; set; }
        public string CumulativeDeaths { get; set; } 
    }
}
