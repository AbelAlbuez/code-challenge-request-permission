using KHENSYS.HRMANAGER.DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KHENSYS.HRMANAGER.DOMAIN.Entities
{
    public class Permission : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
    }
}
