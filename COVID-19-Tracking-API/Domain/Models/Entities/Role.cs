using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace C19Tracking.API.Domain.Entities
{ 
    public class Role : BaseEntity
    { 
        [Column(TypeName = "nvarchar(50)")]
        public string RoleName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string RoleColor { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column(TypeName = "bit")]
        public bool IsPublish { get; set; } 
    }
}
