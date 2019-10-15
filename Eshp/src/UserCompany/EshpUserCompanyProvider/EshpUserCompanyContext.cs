using Microsoft.EntityFrameworkCore;

namespace EshpUserCompanyProvider
{
    public class EshpUserCompanyContext : DbContext
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
    }
}
