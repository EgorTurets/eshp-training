using EshpUserCompanyCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace EshpUserCompanyProvider.DbContext
{
    internal static class ConfigureRelationships
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCompany>()
                .HasKey(uc => new { uc.UserId, uc.CompanyId });
            modelBuilder.Entity<UserCompany>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Companies)
                .HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<UserCompany>()
                .HasOne(uc => uc.Company)
                .WithMany(u => u.Contacts)
                .HasForeignKey(uc => uc.CompanyId);
        }
    }
}
