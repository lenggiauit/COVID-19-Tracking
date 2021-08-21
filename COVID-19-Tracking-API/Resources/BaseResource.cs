using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Resources
{
    public class BaseResource
    {
        public decimal Deaths { get; set; }
        public decimal CumulativeDeaths { get; set; }
        public decimal DeathsLast7Days { get; set; }
        public decimal DeathsLast7DaysChange { get; set; }
        public decimal DeathsPerHundredThousand { get; set; }
        public decimal Confirmed { get; set; }
        public decimal CumulativeConfirmed { get; set; }
        public decimal CasesLast7Days { get; set; }
        public decimal CasesLast7DaysChange { get; set; }
        public decimal CasesPerHundredThousand { get; set; }
        public decimal WkCasePop { get; set; }
        public decimal WkDeathPop { get; set; }
        public decimal Avg7Case { get; set; }
        public decimal Avg7Death { get; set; }
        public decimal Avg7CasePop { get; set; }
        public decimal Avg7DeathPop { get; set; }
    }
}
