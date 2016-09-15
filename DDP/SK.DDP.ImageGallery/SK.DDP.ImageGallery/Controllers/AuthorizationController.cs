using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ImageGallery.Helpers;
using SK.DDP.ViewModels;

namespace SK.DDP.ImageGallery.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult AuthorizationInfo()
        {
            return PartialView();
        }

        public ActionResult Logout()
        {
            CredentialsHelper.Forget();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            var service = new UserManagementService();
            var authenticatedDb = service.Authenticate(userViewModel.Login, userViewModel.Password);
            if (authenticatedDb == null)
            {
                ModelState.AddModelError("", "Invalid login or password.");
                return View(userViewModel);
            }

            CredentialsHelper.RememberAsAuthenticated(userViewModel.Login);
            return RedirectToAction("Index", "UserManagement", new { area = "Administration" });//TODO: add if when roles will occur.
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            var service = new UserManagementService();
            //TODO: register
            var authenticatedDb = service.Authenticate(userViewModel.Login, userViewModel.Password);
            if (authenticatedDb == null)
            {
                ModelState.AddModelError("", "Invalid login or password.");
                return View(userViewModel);
            }

            CredentialsHelper.RememberAsAuthenticated(userViewModel.Login);
            return RedirectToAction("Index", "UserManagement", new { area = "Administration" });//TODO: add if when roles will occur.
        }
    }
}