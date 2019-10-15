using EshpCommon;
using EshpUserCompanyCommon.Models;
using System.Collections.Generic;

namespace UserService.Interfaces
{
    public interface ICompanyService
    {
        ServiceResult<Company> GetById(int id);

        ServiceResult<List<Company>> GetCompanies(int count, int page);
    }
}
