using KHENSYS.HRMANAGER.DOMAIN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KHENSYS.HRMANAGER.APPLICATION.Interfaces
{
    public interface IApplicatoinDbContext
    {
        DbSet<Permission> Permission { get; set; }
        DbSet<PermissionType> PermissionType { get; set; }
        Task<int> SaveChanges();
    }
}
