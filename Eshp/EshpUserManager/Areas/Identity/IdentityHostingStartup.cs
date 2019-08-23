using System;
using EshpUserManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
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
                //context.Configuration.GetConnectionString("EshpUserManagerContextConnection")));
                context.Configuration.GetConnectionString("EshpAzure")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<EshpUserManagerContext>();
            });
        }
    }
}