using System;
using System.Web;
using System.Web.Mvc;
using HomeTask.Models;

namespace HomeTask.Controllers
{
    public class HomeController : Controller
    {
        private bool ValidateCookie()
        {
            var cookie = Request.Cookies[CookieHelper.CookieName];

            return cookie[nameof(Models.User.Name)] != null;
        }

        // GET: Home
        public ActionResult Index()
        {
            if (!ValidateCookie())
                return RedirectToAction("Home");

            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            var cookie = new HttpCookie(CookieHelper.CookieName)
                {
                    [nameof(user.Name)] = user.Name,
                    Expires = DateTime.Now.AddYears(666),
                    Domain = "localhost",
                    Path ="/"
                };

            Response.Cookies.Add(cookie);

            return View();
        }

        public ActionResult Contacts()
        {
            if (!ValidateCookie())
                return RedirectToAction("Home");

            return View();
        }

        public ActionResult About()
        {
            if (!ValidateCookie())
                return RedirectToAction("Home");

            return View();
        }
    }
}