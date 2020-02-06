using EshpCommon;
using EshpUserCompanyCommon.Models;
using System.Collections.Generic;

namespace EshpUserCompanyProvider.Interfaces
{
    public interface ICompanyProvider
    {
        Company GetCompany(int id);

        IList<Company> GetCompanies(PageRequest pageInfo);

        IList<Company> GetCompaniesFor(int baseProductId);

        Company CreateCompany(Company company);

        bool UpdateCompany(Company company);

        bool DeleteCompany(int id);
    }
}
