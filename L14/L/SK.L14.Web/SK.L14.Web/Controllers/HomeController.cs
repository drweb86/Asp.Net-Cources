using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SK.L14.Web.Database;

namespace SK.L14.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //public PartialViewResult Cars()
        //{
        //    return PartialView(Db.Cars);
        //}
        
        public JsonResult Cars()
        {
            return Json(Db.Cars, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Appointment(string id)
        {
            if (id != null && id != "All")
            {
                return PartialView(Db.Appointments.Where(appointment => appointment.Client == id));
            }

            return PartialView(Db.Appointments);
        }
    }
}