using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EshpUserManager.Controllers
{
    public class LoginController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        #region Constructors

        //public LoginController()
        //{
        //    LoginController()
        //}

        public LoginController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        #endregion

        #region Actions

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginVM credentials, string returnUrl)
        {
            var user = await _userManager.FindByLoginAsync(credentials.Login, credentials.Password);
            if (user == null)
            {
                ModelState.AddModelError("signin", "Invalid login or password"); 
            }
            else
            {
                var token = await _userManager.GetAuthenticationTokenAsync(user, credentials.Login, "eshp");
                Response.Cookies.Append(UserService.Constants.TOKEN, token);
            }

            ViewBag.retutnUrl = returnUrl;
            return View();
        }

        public IActionResult SignOut(string returnUrl)
        {
            Response.Cookies.Delete(UserService.Constants.TOKEN);
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        #endregion

    }
}