using EshpProductCommon;
using Microsoft.EntityFrameworkCore;

namespace EshpProductProvider
{
    public class EshpProductDbContext : DbContext
    {
        public EshpProductDbContext(DbContextOptions<EshpProductDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
