using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserCompanyService.Interfaces;

namespace EshpUserCompanyWeb.Controllers
{
    [Route("Company")]
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private ICompanyService _companyService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult CreateCompany()
        {
            return View("CreateCompanyView");
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult CreateCompany(CompanyVM company)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model");
                return new BadRequestResult();
            }
            var result = _companyService.CreateCompany(ConvertToEntity(company));

            if (result.IsErrored)
            {
                return new ContentResult()
                {
                    Content = result.ErrorMessage,
                    StatusCode = 500
                };
            }
            return new OkObjectResult(result.Result);
        }

        public IActionResult Index()
        {
            return View();
        }

        private Company ConvertToEntity(CompanyVM vm)
        {
            if (vm == null) return null;

            var entity = new Company
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
            };
            return entity;
        }
    }
}