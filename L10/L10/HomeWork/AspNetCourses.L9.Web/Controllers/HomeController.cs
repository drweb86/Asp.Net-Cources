using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetCourses.L9.BL.Services;
using AspNetCourses.L9.BL.ViewModels;
using AspNetCourses.L9.Web.Helpers;

namespace AspNetCourses.L9.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AuthenticationService _authenticationService = new AuthenticationService();

        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            //var userViewModel = CredentialsCookieHelper.Load();
            //if (userViewModel == null ||
            //    _authenticationService.Authenticate(userViewModel.Login, userViewModel.Password) == null)
            //    return RedirectToAction("Login", "Authorization");

            return View(_authenticationService.GetUsers());
        }
    }
}