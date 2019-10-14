using EshpUserCompanyProvider;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EshpUserManager.Areas.Identity.IdentityHostingStartup))]
namespace EshpUserManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EshpUserManagerContext>(options =>
                    options.UseSqlServer(
                context.Configuration.GetConnectionString("EshpAzure")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<EshpUserManagerContext>();
            });
        }
    }
}