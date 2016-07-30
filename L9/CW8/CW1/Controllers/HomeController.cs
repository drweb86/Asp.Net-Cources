using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiarheiKuchuk.Test8.BL.Services;
using SiarheiKuchuk.Test8.BL.ViewModels;

namespace SiarheiKuchuk.Test8.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AuthenticationService _authenticationService = new AuthenticationService();

        private bool ValidateCookie()
        {
            var cookie = Request.Cookies[CookieHelper.CookieName];

            return
                    cookie != null &&
                    cookie[nameof(UserViewModel.Login)] != null &&
                    cookie[nameof(UserViewModel.Password)] != null &&
                    _authenticationService.Authenticate(
                        cookie[nameof(UserViewModel.Login)],
                        cookie[nameof(UserViewModel.Password)]);
        }


        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("PrivatePage");
        }


        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public ActionResult ShowIsPolyndrome(bool result)
        {
            if (!ValidateCookie())
                return RedirectToAction("Login");

            return View(result);
        }

        public ActionResult PrivatePage()
        {
            if (!ValidateCookie())
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public ActionResult PrivatePage(string request)
        {
            if (!ValidateCookie())
                return RedirectToAction("Login");

            return RedirectToAction("ShowIsPolyndrome", new { result = request == Reverse(request) });
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (!ModelState.IsValid || !_authenticationService.Authenticate(user))
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