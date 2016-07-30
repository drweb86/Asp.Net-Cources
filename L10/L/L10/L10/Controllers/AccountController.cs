using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using L10.Models;

namespace L10.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(vm.Name, vm.Password))
                {
                    FormsAuthentication.SetAuthCookie(vm.Name, true);
                        //true = browser should save cookie from memory to disk
                    return RedirectToAction("Index", "Home");
                    //FormsAuthentication.RedirectFromLoginPage(); does SetAuthCookie and redirects to previous page
                }

                ModelState.AddModelError("", "Invalid login/password");
            }
            return View(vm);
        }
    }
}