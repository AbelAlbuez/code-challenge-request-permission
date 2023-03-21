using KHENSYS.HRMANAGER.DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KHENSYS.HRMANAGER.DOMAIN
{
    public class PermissionType : BaseEntity
    {
        [Required]
        public string Description { get; set; }
    }
}
