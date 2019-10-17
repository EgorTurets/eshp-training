using EshpCommon;
using EshpUserCompanyCommon.Models;
using System.Collections.Generic;

namespace EshpUserCompanyProvider
{
    public interface ICompanyProvider
    {
        Company GetCompanyById(int id);

        IList<Company> GetCompanies(PageRequest pageInfo);

        IList<Company> GetCompaniesByProduct(int baseProductId);

        Company CreateCompany(Company company);

        bool UpdateCompany(int id, Company company);

        bool DeleteCompany(int id);
    }
}
