using KHENSYS.HRMANAGER.DOMAIN;
using KHENSYS.HRMANAGER.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KHENSYS.HRMANAGER.APPLICATION.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Permission> Permissions { get; set; }
        DbSet<PermissionType> PermissionTypes { get; set; }
        Task<int> SaveChanges();
    }
}
