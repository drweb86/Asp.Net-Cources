using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CW1.DAL;
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
                    cookie[nameof(DAL.User.Login)] != null &&
                    cookie[nameof(DAL.User.Password)] != null &&
                    DbHelper.IsAuthenticated(
                        cookie[nameof(DAL.User.Login)],
                        cookie[nameof(DAL.User.Password)]);
        }


        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("PrivatePage");
        }

        public ActionResult PrivatePage()
        {
            if (!ValidateCookie())
                return RedirectToAction("Login");

            var result = new PrivatePageModel(
                DbHelper.Numbers,
                DbHelper.Numbers.Min(),
                DbHelper.Numbers.Max());

            return View(result);
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

            return RedirectToAction("PrivatePage");
        }
    }
}