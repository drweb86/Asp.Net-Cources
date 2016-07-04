using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CW1.Models;

namespace CW1.Controllers
{
    public class HomeController : Controller
    {
        private bool ValidateCookie()
        {
            var cookie = Request.Cookies[CookieHelper.CookieName];

            return
                    cookie != null &&
                    cookie[nameof(Models.User.Login)] != null &&
                    cookie[nameof(Models.User.Password)] != null &&
                    DbHelper.IsAuthenticated(new User(
                       cookie[nameof(Models.User.Login)],
                       cookie[nameof(Models.User.Password)]));
                ;
        }


        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Factorial");
        }

        public ActionResult Factorial()
        {
            if (!ValidateCookie())
                return RedirectToAction("Login");

            return View();
        }

        private int CalculateFactorial(int number)
        {
            if (number == 1)
                return 1;

            return number*CalculateFactorial(number - 1);
        }

        [HttpPost]
        public ActionResult Factorial(Factorial factorial)
        {
            if (!ValidateCookie())
                return RedirectToAction("Login");

            if (!ModelState.IsValid)
                return View(factorial);

            return View(new Factorial() {Result = CalculateFactorial(factorial.Number)});
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!ModelState.IsValid || !DbHelper.IsAuthenticated(user))
                return View(user);

            var cookie = new HttpCookie(CookieHelper.CookieName)
            {
                [nameof(user.Login)] = user.Login,
                [nameof(user.Password)] = user.Password,
                Expires = DateTime.Now.AddYears(666),
                Domain = "localhost",
                Path = "/"
            };

            Response.Cookies.Add(cookie);

            return RedirectToAction("Factorial");
        }
    }
}