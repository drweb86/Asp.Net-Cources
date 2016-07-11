using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItAcademy.Galery.BL;
using ItAcademy.Galery.ViewModels;

namespace ItAcademy.Galery.Web.Controllers
{
    public class HomeController : Controller
    {
        private PhotoService _photoService = new PhotoService();

        // GET: Home
        public ActionResult Index()
        {
            return View(_photoService.GetPhotos());
        }
    }
}