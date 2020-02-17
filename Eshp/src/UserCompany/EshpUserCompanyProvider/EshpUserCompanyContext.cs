﻿using EshpUserCompanyCommon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EshpUserCompanyProvider
{
    public class EshpUserCompanyContext : IdentityDbContext<IdentityUser>
    {
        public EshpUserCompanyContext(DbContextOptions<EshpUserCompanyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
    }
}
