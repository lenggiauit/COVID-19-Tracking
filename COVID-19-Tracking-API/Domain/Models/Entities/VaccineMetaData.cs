using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public abstract class VaccineMetaData
    {
        public string ISO3 { get; set; }
        public string VaccineName { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public DateTime AuthorizationDate { get; set; }

    }
}
