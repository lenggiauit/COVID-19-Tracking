using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class VaccineData : VaccineMetaData
    {
        public string CountryName { get; set; }
        public string Region { get; set; }
        public int PersonFullyVaccinated { get; set; }
        public int PersonVaccinated1PlusDose { get; set; }
        public double PersonFullyVaccinatedPer100 { get; set; }
        public double PersonVaccinated1PlusDosePer100 { get; set; } 
        public string VaccinesUsed { get; set; }
        public DateTime DateUpdated { get; set; }
        public int TotalVaccinations { get; set; }




    }
}
