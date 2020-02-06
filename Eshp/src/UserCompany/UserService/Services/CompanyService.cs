using System;
using System.Collections.Generic;
using System.Text;
using EshpCommon;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyProvider.Interfaces;
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

        public ServiceResult<Company> Get(int id)
        {
            if (id <= 0)
            {
                return ServiceResult<Company>.CreateErrorResult("Id must be great than 0");
            }

            var result = _companyProvider.GetCompany(id);

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

        public ServiceResult<IList<Company>> GetCompaniesForProduct(int baseProductId)
        {
            if (baseProductId <= 0)
            {
                return ServiceResult<IList<Company>>.CreateErrorResult("BaseProductId must be more than 0");
            }

            var result = _companyProvider.GetCompaniesFor(baseProductId);

            return ServiceResult<IList<Company>>.CreateSuccessResult(result);
        }

        public ServiceResult<Company> CreateCompany(Company company)
        {
            if (company == null)
            {
                return ServiceResult<Company>.CreateErrorResult("Company cannot be null");
            }
            if (String.IsNullOrWhiteSpace(company.Name))
            {
                return ServiceResult<Company>.CreateErrorResult("Name is required");
            }

            var result = _companyProvider.CreateCompany(company);
            if (result != null)
            {
                return ServiceResult<Company>.CreateSuccessResult(result);
            }
            return ServiceResult<Company>.CreateErrorResult("Error creating Company");
        }

        public ServiceResult<bool> UpdateCompany(Company company)
        {
            if (company == null)
                return ServiceResult<bool>.CreateErrorResult($"{nameof(company)} can not be null");
            if (company.Id <= 0)
                return ServiceResult<bool>.CreateErrorResult($"{nameof(company.Id)} can not be less than 1");
            if (String.IsNullOrWhiteSpace(company.Name))
                return ServiceResult<bool>.CreateErrorResult($"{nameof(company.Name)} is required");

            var result = _companyProvider.UpdateCompany(company);

            return ServiceResult<bool>.CreateSuccessResult(result);
        }

        public ServiceResult<bool> DeleteCompany(int id)
        {
            if (id <= 0)
                return ServiceResult<bool>.CreateErrorResult($"{nameof(id)} can not be less than 1");

            var result = _companyProvider.DeleteCompany(id);
            return ServiceResult<bool>.CreateSuccessResult(result);
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
