using Microsoft.EntityFrameworkCore;

namespace EshpUserCompanyCommon
{
    public class EshpUserCompanyContext : DbContext
    {
        public EshpUserCompanyContext(DbContextOptions<EshpUserCompanyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
