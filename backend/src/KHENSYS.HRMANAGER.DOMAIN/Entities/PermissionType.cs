using KHENSYS.HRMANAGER.DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KHENSYS.HRMANAGER.DOMAIN.Entities
{
    public class PermissionType : BaseEntity
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public ICollection<Permission> Permission { get; set; }
    }
}
