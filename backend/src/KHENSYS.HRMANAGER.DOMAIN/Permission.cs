using KHENSYS.HRMANAGER.DOMAIN.Common;
using System;

namespace KHENSYS.HRMANAGER.DOMAIN
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PermissionType { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
