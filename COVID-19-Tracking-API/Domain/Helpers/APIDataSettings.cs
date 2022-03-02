using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Helpers
{
    public class APIDataSettings
    {
        public List<RegionData> Regions { get; set; }
        public List<APIOption> ListAPIOptions { get; set; }
        public string DetailUrl { get; set; }
    }
}
