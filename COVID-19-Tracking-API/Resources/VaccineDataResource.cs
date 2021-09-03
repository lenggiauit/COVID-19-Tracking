using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    public class VaccineDataResource
    { 
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public decimal PersonFullyVaccinated { get; set; }
        public decimal PersonVaccinated1PlusDose { get; set; }
        public double PersonFullyVaccinatedPer100 { get; set; }
        public double PersonVaccinated1PlusDosePer100 { get; set; }
        public string VaccinesUsed { get; set; }
        public DateTime DateUpdated { get; set; }
        public decimal TotalVaccinations { get; set; }
    }
}
