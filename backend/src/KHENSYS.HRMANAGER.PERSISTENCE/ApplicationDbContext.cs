using KHENSYS.HRMANAGER.APPLICATION.Interfaces;
using KHENSYS.HRMANAGER.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KHENSYS.HRMANAGER.PERSISTENCE
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType { Id=1, Description = "Enfermedad" },
                new PermissionType { Id = 2, Description = "Diligencias" },
                new PermissionType { Id = 3, Description = "Familia" }
            );
        }
    }
}
