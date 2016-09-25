using System;
using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ImageGallery.Helpers;
using SK.DDP.ViewModels;

namespace SK.DDP.ImageGallery.Areas.Administration.Controllers
{
    [Authorize]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public ActionResult Index()
        {
            return View(_userManagementService.GetUsers());
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserProfile userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            string error;
            if (!_userManagementService.Register(userViewModel, out error))
            {
                ModelState.AddModelError("", $"Can't register user: {error}.");
                return View(userViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditUser(string login)
        {
            var user = _userManagementService.GetUser(login);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(UserProfile userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            string error;
            if (!_userManagementService.Update(userViewModel, out error))
            {
                ModelState.AddModelError("", $"Can't update user: {error}.");
                return View(userViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(string login)
        {
            _userManagementService.Delete(login);

            if (string.Compare(
                CredentialsHelper.GetAuthenticatedUserName(),
                login,
                StringComparison.OrdinalIgnoreCase) == 0)
            {
                CredentialsHelper.Forget();
                return RedirectToAction("Login", "Authorization");
            }

            return RedirectToAction("Index");
        }
    }
}