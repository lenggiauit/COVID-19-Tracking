using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Resources
{
    public class UserResource
    {
        public Guid UserID { get; set; } 
        public string UserName { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Images { get; set; } 
        public int RoleID { get; set; } 
        public string AccessToken { get; set; } 
        public string UserPhone { get; set; } 
        public string UserEmail { get; set; } 
        public string Address { get; set; } 
        public string Note { get; set; } 
        public string FirebaseUid { get; set; } 
        public bool IsActive { get; set; } 
        public bool IsBanned { get; set; } 
        public List<PermissionResource> Permissions { get; set; } 
    }
}
