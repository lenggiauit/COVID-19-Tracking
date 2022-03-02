using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Helpers
{
    public class APIOption
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Method { get; set; } 
        public string[] NodeNames { get; set; } 
        public string StaticQueryUrl { get; set; }
        public string StaticQueryNode { get; set; }


    }
     
    public class RegionData
    {
        public string Name { get; set; }
        public string Countries { get; set; }
    }
}
