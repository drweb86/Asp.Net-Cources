using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ImageGallery.Helpers;
using SK.DDP.ViewModels;

namespace SK.DDP.ImageGallery.Controllers.Shared
{
    public class AuthorizationController : Controller
    {
        public ActionResult AuthorizationInfo()
        {
            return PartialView(CredentialsHelper.IsAuthenticated());
        }

        public ActionResult Logout()
        {
            CredentialsHelper.Forget();
            return RedirectToAction("Login");
        }

        public ActionResult Login(bool partial = false)
        {
            if (partial)
            {
                ViewBag.Partial = true;
                return PartialView();
            }
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

        public ActionResult Register(bool partial = false)
        {
            if (partial)
            {
                ViewBag.Partial = true;
                return PartialView();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
                return View(userProfile);

            var service = new UserManagementService();

            if (service.GetUser(userProfile.Login) != null)
            {
                ModelState.AddModelError("", "Username is already used. Try different.");
                return View(userProfile);
            }

            string error;
            if (!service.Register(userProfile, out error))
            {
                ModelState.AddModelError("", error);
                return View(userProfile);
            }

            CredentialsHelper.RememberAsAuthenticated(userProfile.Login);
            return RedirectToAction("Index", "UserManagement", new { area = "Administration" });//TODO: add if when roles will occur.
        }
    }
}