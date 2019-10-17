using EshpCommon;
using EshpUserCompanyCommon.Models;
using System.Collections.Generic;

namespace UserCompanyService.Interfaces
{
    public interface ICompanyService
    {
        ServiceResult<Company> GetById(int id);

        ServiceResult<List<Company>> GetCompanies(PageRequest pageInfo);

        ServiceResult<List<Company>> GetByProductId(int baseProductId);

        ServiceResult<Company> CreateCompany(Company company);

        ServiceResult<bool> UpdateCompany(int id, Company company);

        ServiceResult<bool> DeleteCompany(int id);
    }
}
