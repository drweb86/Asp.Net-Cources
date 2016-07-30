using System.Web.Mvc;
using AspNetCourses.L11CW.BL.Services;
using AspNetCourses.L11CW.BL.ViewModels;
using AspNetCourses.L11CW.Web;
using AspNetCourses.L11CW.Web.Helpers;

namespace AspNetCourses.L9.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AuthenticationService _service = new AuthenticationService();
        
        
        // GET: Authorization
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            CredentialsHelper.Forget();

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
                ModelState.AddModelError("", "Login / password is incorrect");
                return View(vm);
            }

            CredentialsHelper.RememberAsAuthenticated(identity.Login);

            return RedirectToAction("Index", "Home");
        }
    }
}