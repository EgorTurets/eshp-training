using System.Collections.Generic;
using EshpCommon;
using EshpUserCompanyCommon.Models;
using UserCompanyService.Interfaces;

namespace UserCompanyService.Services
{
    public class CompanyService : ICompanyService
    {
        public ServiceResult<Company> CreateCompany(Company company)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<bool> DeleteCompany(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<Company> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<List<Company>> GetByProductId(int baseProductId)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<List<Company>> GetCompanies(int count, int page)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<List<Company>> GetCompanies(PageRequest pageInfo)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<bool> UpdateCompany(int id, Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}
