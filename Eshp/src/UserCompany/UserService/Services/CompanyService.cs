using System;
using System.Collections.Generic;
using System.Text;
using EshpCommon;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyProvider;
using UserCompanyService.Interfaces;

namespace UserCompanyService.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyProvider _companyProvider;
        public CompanyService (ICompanyProvider companyProvider)
        {
            _companyProvider = companyProvider;
        }

        public ServiceResult<Company> GetById(int id)
        {
            if (id <= 0)
            {
                return ServiceResult<Company>.CreateErrorResult("Id must be great than 0");
            }

            var result = _companyProvider.GetCompanyById(id);

            return ServiceResult<Company>.CreateSuccessResult(result);
        }

        public ServiceResult<IList<Company>> GetCompanies(PageRequest pageInfo)
        {
            string errorMessage;
            var isValid = ValidatePageRequest(pageInfo, out errorMessage);

            if (!isValid)
            {
                return ServiceResult<IList<Company>>.CreateErrorResult(errorMessage);
            }

            var result = _companyProvider.GetCompanies(pageInfo);

            return ServiceResult<IList<Company>>.CreateSuccessResult(result);
        }

        public ServiceResult<IList<Company>> GetByProductId(int baseProductId)
        {
            if (baseProductId <= 0)
            {
                return ServiceResult<IList<Company>>.CreateErrorResult("BaseProductId must be more than 0");
            }

            var result = _companyProvider.GetCompaniesByProduct(baseProductId);

            return ServiceResult<IList<Company>>.CreateSuccessResult(result);
        }

        public ServiceResult<Company> CreateCompany(Company company)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<bool> UpdateCompany(int id, Company company)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<bool> DeleteCompany(int id)
        {
            throw new System.NotImplementedException();
        }

        private bool ValidatePageRequest(PageRequest pageInfo, out string message)
        {
            var messageBuilder = new StringBuilder();

            if (pageInfo.PageNumber <= 0)
            {
                messageBuilder.AppendLine("Page must be more than 0.");
            }
            if (pageInfo.ResultsInPage <= 0)
            {
                messageBuilder.AppendLine("Results count must be more than 0.");
            }

            message = messageBuilder.ToString();
            return String.IsNullOrWhiteSpace(message);
        }
    }
}
