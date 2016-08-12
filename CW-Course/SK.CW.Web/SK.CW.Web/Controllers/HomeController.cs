using System.Web.Mvc;
using SK.CW.BL;
using SK.CW.Web.Models;

namespace SK.CW.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var allUsers = new UsersService().GetUsers();

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

            new UsersService().AddUser(pageViewModel.GetUserViewModel(), pageViewModel.GetDetailViewModel());

            return RedirectToAction("Index");
        }
    }
}