using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SK.CW.BL;

namespace SK.CW.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var allUsers = new UsersService().GetUsers();

            return View(allUsers);
        }
    }
}