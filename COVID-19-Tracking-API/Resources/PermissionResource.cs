using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Resources
{
    public class PermissionResource
    { 
        public int PermissionID { get; set; } 
        public string PermissionName { get; set; } 
        public string PermissionCode { get; set; } 
        public string PermissionGroup { get; set; } 
    }
}
