using System.Web.Mvc;
using AspNetCourses.L11CW.BL.Services;
using AspNetCourses.L9.Web.Models;

namespace AspNetCourses.L9.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AuthenticationService _authenticationService = new AuthenticationService();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nod(NodPageViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            return RedirectToAction("NodResult", new {result = MathHelper.GetNOD(vm.A, vm.B)});
        }

        public ActionResult NodResult(int result)
        {
            return View(result);
        }
    }
}