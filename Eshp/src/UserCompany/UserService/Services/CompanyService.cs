using System.Collections.Generic;
using EshpCommon;
using EshpUserCompanyCommon.Models;
using UserService.Interfaces;

namespace UserService.Services
{
    public class CompanyService : ICompanyService
    {
        public ServiceResult<Company> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<List<Company>> GetCompanies(int count, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
