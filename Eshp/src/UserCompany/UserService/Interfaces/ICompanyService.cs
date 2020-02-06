using EshpCommon;
using EshpUserCompanyCommon.Models;
using System.Collections.Generic;

namespace UserCompanyService.Interfaces
{
    public interface ICompanyService
    {
        ServiceResult<Company> Get(int id);

        ServiceResult<IList<Company>> GetCompanies(PageRequest pageInfo);

        ServiceResult<IList<Company>> GetCompaniesForProduct(int baseProductId);

        ServiceResult<Company> CreateCompany(Company company);

        ServiceResult<bool> UpdateCompany(Company company);

        ServiceResult<bool> DeleteCompany(int id);
    }
}
