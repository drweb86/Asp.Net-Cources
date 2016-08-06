using Microsoft.Practices.Unity;
using SK.L16.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SK.L16.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IPhotoService PhotoService { get; set; }

        //private readonly IPhotoService _photoService;

        //public HomeController(IPhotoService photoService)
        //{
        //    _photoService = photoService;
        //}

        // GET: Home
        public ActionResult Index()
        {
            return View(PhotoService.GetPhotos());
        }
    }
}