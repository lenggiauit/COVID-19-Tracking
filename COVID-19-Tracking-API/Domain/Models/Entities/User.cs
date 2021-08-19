using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace C19Tracking.API.Domain.Entities
{ 
    public class User : BaseEntity
    { 
        [Column(TypeName = "nvarchar(250)")]
        public string FirebaseUid { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Images { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; } 

        [ForeignKey("Role")]
        public Guid RoleID { get; set; } 

        public virtual Role Role { get; set; }

        public virtual List<Permission> Permissions { get; set; }
  
        [Column(TypeName = "nvarchar(20)")]
        public string UserPhone { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string UserEmail { get; set; }
          
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Note { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column(TypeName = "bit")]
        public bool IsBanned { get; set; } 
    }
}
