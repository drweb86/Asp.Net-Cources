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
            return PartialView(CredentialsHelper.IsAuthenticated());
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

        public ActionResult LoginPartial()
        {
            ViewBag.Partial = true;
            return PartialView("Login");
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

        public ActionResult RegisterPartial()
        {
            ViewBag.Partial = true;
            return PartialView("Register");
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