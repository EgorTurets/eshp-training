using System;
using EshpUserCompanyProvider;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EshpUserCompanyWeb.Areas.Identity.IdentityHostingStartup))]
namespace EshpUserCompanyWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EshpUserCompanyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserCompany")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<EshpUserCompanyContext>();
            });
        }
    }
}