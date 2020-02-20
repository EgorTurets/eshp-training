using EshpUserCompanyProvider.DbContext;
using EshpUserCompanyProvider.Interfaces;
using EshpUserCompanyProvider.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserCompanyService.Interfaces;
using UserCompanyService.Services;

namespace EshpUserCompanyWeb
{
    internal class DISettings
    {
        internal static void ConfigureUserCompanyServices(IServiceCollection services)
        {
            services.AddTransient(typeof(ICompanyService), typeof(CompanyService));
            services.AddTransient(typeof(ICompanyProvider), typeof(CompanyProvider));

            services.AddLogging();
        }
    }
}
