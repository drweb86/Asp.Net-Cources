using System;
using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ImageGallery.Helpers;
using SK.DDP.ViewModels;

namespace SK.DDP.ImageGallery.Controllers
{
    [Authorize]
    public class UserManagementController : Controller
    {
        public ActionResult Index()
        {
            return View(new UserManagementService().GetUsers());
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            string error;
            if (!new UserManagementService().Register(userViewModel, out error))
            {
                ModelState.AddModelError("", $"Can't register user: {error}.");
                return View(userViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditUser(string login)
        {
            var user = new UserManagementService().GetUser(login);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            string error;
            if (!new UserManagementService().Update(userViewModel, out error))
            {
                ModelState.AddModelError("", $"Can't update user: {error}.");
                return View(userViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(string login)
        {
            new UserManagementService().Delete(login);

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