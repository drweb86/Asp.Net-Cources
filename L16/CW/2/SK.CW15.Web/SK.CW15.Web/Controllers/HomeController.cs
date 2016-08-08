using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SK.CW15.Bl;

namespace SK.CW15.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShopService _shopService;

        public HomeController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: Home
        public ActionResult Index(string order)
        {
            return View();
        }

        public JsonResult Priceless(string price)
        {
            GoodViewModel good;
            if (price == "valueble")
            {
                good = _shopService.GetGoods()
                    .OrderByDescending(item=>item.Price)
                    .FirstOrDefault();
            }
            else
            {
                good = _shopService.GetGoods()
                    .OrderBy(item => item.Price)
                    .FirstOrDefault();
            }

            return Json(good, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTable(string price)
        {
            IEnumerable<GoodViewModel> goods;
            if (price == "valueble")
            {
                goods = _shopService.GetGoods()
                    .OrderByDescending(item => item.Price)
                    .ToArray();
            }
            else
            {
                goods = _shopService.GetGoods();
            }

            return Json(goods, JsonRequestBehavior.AllowGet);
        }
    }
}