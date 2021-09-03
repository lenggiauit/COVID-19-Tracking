using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    public class TotalVaccineDataResource
    { 
        public decimal PersonFullyVaccinated { get; set; }
        public decimal PersonVaccinated1PlusDose { get; set; } 
        public string VaccinesUsed { get; set; } 
        public decimal TotalVaccinations { get; set; }
    }
}
