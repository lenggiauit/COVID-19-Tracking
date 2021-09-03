using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    public class CovidDataByDayGroupResource : CovidDataByRegionResource
    {
        public DateTime DateReport { get; set; } 
    }
}
