using KHENSYS.HRMANAGER.DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KHENSYS.HRMANAGER.DOMAIN.Entities
{
    public class Permission : BaseEntity
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
    }
}
