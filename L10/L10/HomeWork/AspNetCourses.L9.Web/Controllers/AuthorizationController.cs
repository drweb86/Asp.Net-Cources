using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspNetCourses.L9.BL.Services;
using AspNetCourses.L9.BL.ViewModels;
using AspNetCourses.L9.Web.Helpers;

namespace AspNetCourses.L9.Web.Controllers
{
    public class AuthorizationController : BaseController
    {
        private readonly AuthenticationService _service = new AuthenticationService();

        [Authorize]
        public ActionResult Delete(string userName)
        {
            _service.Delete(userName);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (!_service.Register(vm))
                return View(vm);

            CredentialsCookieHelper.Save(Response, vm);

            return RedirectToAction("Index", "Home");
        }

        // GET: Authorization
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            CredentialsCookieHelper.Expire(Response);

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel vm)
        {
            if (!ModelState.IsValidField(vm.Login) ||
                !ModelState.IsValidField(vm.Password))
                return View(vm);

            var identity = _service.Authenticate(vm.Login, vm.Password);
            if (identity == null)
            {
                ModelState.AddModelError("", Resources.AuthorizationController_LoginPasswordIsIncorrect);
                return View(vm);
            }

            CredentialsCookieHelper.Save(Response, identity);

            return RedirectToAction("Index", "Home");
        }
    }
}