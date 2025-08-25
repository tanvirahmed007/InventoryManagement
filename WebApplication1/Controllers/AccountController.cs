using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public AccountController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public ISession session => HttpContext.Session;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string btnSubmit, BaseAccount baseAccount)
        {
            if (btnSubmit == "Forgot password?")
            {
                return RedirectToAction("ForgetPassword", "Account");
            }

            if (btnSubmit == "Login")
            {
                // ✅ Create BaseAccount with HttpContextAccessor and Configuration
                var account = new BaseAccount(_httpContextAccessor, _configuration)
                {
                    Username = baseAccount.Username,
                    Password = baseAccount.Password
                };

                bool verifyStatus = account.Verify();

                if (verifyStatus)
                {
                    // ✅ Save logged-in user in Session
                    HttpContext.Session.SetString("User", baseAccount.Username);

                    // ✅ Redirect to Dashboard in Home controller
                    return RedirectToAction("Dashboard", "Home");
                }

                ViewBag.Error = "Invalid username or password";
            }

            return View(baseAccount);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            // Clear the session and redirect to the login page
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }
    }
}
