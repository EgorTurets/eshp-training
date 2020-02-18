using EshpUserCompanyCommon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EshpUserCompanyProvider.DbContext
{
    public class EshpUserCompanyContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public EshpUserCompanyContext(DbContextOptions<EshpUserCompanyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelationships.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
    }
}
