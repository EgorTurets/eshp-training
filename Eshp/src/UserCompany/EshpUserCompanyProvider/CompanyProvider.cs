using EshpCommon;
using EshpUserCompanyCommon.Models;
using System;
using System.Collections.Generic;

namespace EshpUserCompanyProvider
{
    public class CompanyProvider : ICompanyProvider
    {
        public Company CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetCompanies(PageRequest pageInfo)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetCompaniesFor(int baseProductId)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCompany(int id, Company company)
        {
            throw new NotImplementedException();
        }
    }
}
