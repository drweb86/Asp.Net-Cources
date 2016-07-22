using System.Web.Mvc;
using AspNetCourses.L9.BL.Services;

namespace AspNetCourses.L9.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AuthenticationService _authenticationService = new AuthenticationService();

        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View(_authenticationService.GetUsers());
        }
    }
}