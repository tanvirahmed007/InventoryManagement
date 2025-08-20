using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public ISession session => HttpContext.Session;
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string btnSubmit, string txtEmail, string txtPass)
        {
            if (btnSubmit == "Forgot password?")
            {
                return RedirectToAction("ForgetPassword", "Account");
            }
            if (btnSubmit == "Login")
            {
                // Corrected the syntax for setting a session value
                //session["User"] = "";
                HttpContext.Session.SetString("User", "Tanvir@gmail.com");

                if (txtEmail.ToUpper() == "Tanvir@gmail.com".ToUpper() && txtPass == "1234")
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            return View();
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
