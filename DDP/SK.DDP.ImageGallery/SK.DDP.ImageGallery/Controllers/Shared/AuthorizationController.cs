using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ImageGallery.Helpers;
using SK.DDP.ViewModels;

namespace SK.DDP.ImageGallery.Controllers.Shared
{
    public class AuthorizationController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public AuthorizationController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

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

            var authenticatedDb = _userManagementService.Authenticate(userViewModel.Login, userViewModel.Password);
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

            if (_userManagementService.GetUser(userProfile.Login) != null)
            {
                ModelState.AddModelError("", "Username is already used. Try different.");
                return View(userProfile);
            }

            string error;
            if (!_userManagementService.Register(userProfile, out error))
            {
                ModelState.AddModelError("", error);
                return View(userProfile);
            }

            CredentialsHelper.RememberAsAuthenticated(userProfile.Login);
            return RedirectToAction("Index", "UserManagement", new { area = "Administration" });//TODO: add when roles will occur.
        }
    }
}