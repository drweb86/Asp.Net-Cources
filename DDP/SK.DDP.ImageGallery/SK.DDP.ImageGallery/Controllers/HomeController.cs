using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ViewModels;

namespace SK.DDP.ImageGallery.Controllers
{
    public class HomeController : Controller
    {
        //public void Init()
        //{
        //    new UserManagementService().Register(new UserViewModel("admin", "adminko"));
        //}

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
    }
}