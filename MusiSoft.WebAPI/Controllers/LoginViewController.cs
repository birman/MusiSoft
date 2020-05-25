using Google.Authenticator;
using MusiSoft.Entities;
using MusiSoft.Helpers;
using MusiSoft.Services.Contract.Contract;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace MusiSoft.WebAPI.Controllers
{
    public class LoginViewController : Controller
    {
        private string key = "2-P3:ti0e&{q:btLZ(66:8Xgd:o:j2~4|P`$%!Al]k!(T#y0UK|hy<`p*Kc<gO$";
        private IUserService userService;

        public LoginViewController() : this(DependencyFactory.Resolve<IUserService>())
        {
        }

        public LoginViewController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: LoginView
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [System.Obsolete]
        public ActionResult Index(UserViewModel user)
        {
            var _user = userService.GetUser(user);

            if (_user != null)
            {
                ConfigurationSettings.AppSettings["company"] = _user.CompanyId.ToString();
                //FormsAuthentication.SetAuthCookie(_user.Name, false);
                TempData["SetAuthCookie"] = _user.Name;

                return RedirectToAction("LoginTwoFactorAuthenticator", "LoginView");
            }
            else
            {
                ViewBag.MensajeLogin = "Invalid user";
            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        //[Authorize]
        public ActionResult LoginTwoFactorAuthenticator()
        {
            var authenticator = new TwoFactorAuthenticator();
            var result = authenticator.GenerateSetupCode("MusiSoft", "Autenticador", key, false, 300);

            ViewBag.QRCode = result.QrCodeSetupImageUrl;

            return View();
        }

        //[Authorize]
        public ActionResult ValidateTwoFactorAuthenticator()
        {
            var token = Request["token"];
            var authenticator = new TwoFactorAuthenticator();
            var isValido = authenticator.ValidateTwoFactorPIN(key, token);
            var userName = TempData["SetAuthCookie"];
            if (isValido && userName != null)
            {
                
                FormsAuthentication.SetAuthCookie(userName.ToString(), false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "LoginView");
            }
        }
    }
}