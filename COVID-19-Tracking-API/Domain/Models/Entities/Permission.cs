using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Entities
{
    public class Permission : BaseEntity
    {
        [Column(TypeName = "nvarchar(150)")]
        public string PermissionName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PermissionCode { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PermissionGroup { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
