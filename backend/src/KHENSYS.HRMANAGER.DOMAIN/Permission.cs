using KHENSYS.HRMANAGER.DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KHENSYS.HRMANAGER.DOMAIN
{
    public class Permission : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public ICollection<PermissionType> PermissionType { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
    }
}
