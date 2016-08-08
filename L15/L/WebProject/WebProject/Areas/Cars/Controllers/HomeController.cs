using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Areas.Cars.Controllers
{
    public class HomeController : Controller
    {
        // GET: Cars/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}