using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshpUserCompanyCommon.Models;
using EshpUserCompanyWeb.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EshpUserCompanyWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public AccountController(SignInManager<User> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new NotFoundResult();
        }
    }
}