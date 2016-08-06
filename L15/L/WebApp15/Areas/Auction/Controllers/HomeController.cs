using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp15.Areas.Auction.Controllers
{
    public class HomeController : Controller
    {
        // GET: Auction/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}