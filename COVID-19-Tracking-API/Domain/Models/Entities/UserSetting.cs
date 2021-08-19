using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace C19Tracking.API.Domain.Entities
{
    public class UserSetting: BaseEntity
    { 
        [Column(TypeName = "nvarchar(100)")]
        public string SettingName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string SettingValue { get; set; } 
        [Column(TypeName = "nvarchar(250)")]
        public string SettingValidation { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string SettingHintText { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
    }
}
