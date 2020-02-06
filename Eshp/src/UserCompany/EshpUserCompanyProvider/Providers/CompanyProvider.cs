using EshpCommon;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EshpUserCompanyProvider.Providers
{
    public class CompanyProvider : ICompanyProvider
    {
        private EshpUserCompanyContext _ucContext;

        public CompanyProvider(EshpUserCompanyContext context)
        {
            _ucContext = context;
        }

        public Company CreateCompany(Company company)
        {
            if (company != null)
            {
                _ucContext.Companies.Add(company);
                _ucContext.SaveChanges();
                return company;
            }
            return null;
        }

        public bool DeleteCompany(int id)
        {
            var company = GetCompany(id);
            if (company != null)
            {
                _ucContext.Companies.Remove(company);
                _ucContext.SaveChanges();

                return true;
            }

            return false;
        }

        public IList<Company> GetCompanies(PageRequest pageInfo)
        {
            if (pageInfo == null)
            {
                return null;
            }
            var result = _ucContext.Companies.Skip(pageInfo.ResultsInPage * (pageInfo.PageNumber - 1)).Take(pageInfo.ResultsInPage);

            return result.ToList();
        }

        public IList<Company> GetCompaniesFor(int baseProductId)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id)
        {
            return _ucContext.Companies.Find(id);
        }

        public bool UpdateCompany(Company company)
        {
            if (company != null)
            {
                _ucContext.Companies.Update(company);
                _ucContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
