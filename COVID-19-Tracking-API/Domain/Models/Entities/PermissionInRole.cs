using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace C19Tracking.API.Domain.Entities
{
    public class PermissionInRole : BaseEntity
    { 
        [ForeignKey("Permission")]
        public Guid PermissionId { get; set; }

        public virtual Permission Permissions { get; set; }
         
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

    }
}