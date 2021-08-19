using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Models.Entities
{
    public class Covid19Data
    { 
        public DateTime Day { get; set; }
        public int Deaths { get; set; }
        public int CumulativeDeaths { get; set; }
        public int DeathsLast7Days { get; set; }
        public int DeathsLast7DaysChange { get; set; }
        public int DeathsPerHundredThousand { get; set; }
        public int Confirmed { get; set; }
        public int CumulativeConfirmed { get; set; }
        public int CasesLast7Days { get; set; }
        public int CasesLast7DaysChange { get; set; }
        public int CasesPerHundredThousand { get; set; }
        public int WkCasePop { get; set; }
        public int WkDeathPop { get; set; }
        public int Avg7Case { get; set; } 
        public int Avg7Death { get; set; }
        public int Avg7CasePop { get; set; }
        public int Avg7DeathPop { get; set; } 

    }
}
