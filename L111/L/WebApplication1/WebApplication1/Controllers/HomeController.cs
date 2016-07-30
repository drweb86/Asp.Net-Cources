using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Database;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Db.Images
                );
        }

        public ActionResult Page(int? pageId)
        {
            return View();
        }

        public ActionResult Image(int id)
        {
            return View(Db.Images.Single(image=>image.Id == id));
        }
    }
}