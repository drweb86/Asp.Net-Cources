using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly FurnitureDal _db = new FurnitureDal();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.GetBeds());
        }

        public ActionResult Delete(int id)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}