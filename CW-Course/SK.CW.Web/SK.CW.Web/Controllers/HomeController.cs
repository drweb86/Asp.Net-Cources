using System.Web.Mvc;
using SK.CW.BL;
using SK.CW.Web.Models;

namespace SK.CW.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService _usersService;

        public HomeController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        public ActionResult Index()
        {
            var allUsers = _usersService.GetUsers();

            return View(allUsers);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(AddUserPageViewModel pageViewModel)
        {
            if (!ModelState.IsValid)
                return View(pageViewModel);

            _usersService.AddUser(pageViewModel.GetUserViewModel(), pageViewModel.GetDetailViewModel());

            return RedirectToAction("Index");
        }
    }
}