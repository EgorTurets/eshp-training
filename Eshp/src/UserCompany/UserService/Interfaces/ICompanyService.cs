﻿using EshpCommon;
using EshpUserCompanyCommon.Models;
using System.Collections.Generic;

namespace UserCompanyService.Interfaces
{
    public interface ICompanyService
    {
        ServiceResult<Company> GetById(int id);

        ServiceResult<IList<Company>> GetCompanies(PageRequest pageInfo);

        ServiceResult<IList<Company>> GetByProductId(int baseProductId);

        ServiceResult<Company> CreateCompany(Company company);

        ServiceResult<bool> UpdateCompany(int id, Company company);

        ServiceResult<bool> DeleteCompany(int id);
    }
}
