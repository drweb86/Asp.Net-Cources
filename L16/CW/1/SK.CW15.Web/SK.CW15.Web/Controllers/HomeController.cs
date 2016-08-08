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
            IEnumerable<GoodViewModel> goods;
            if (order == null || order == "default")
            {
                goods = _shopService.GetGoods();
            }
            else
            {
                goods = _shopService.GetGoods()
                    .OrderBy(item => item.Price)
                    .ToArray();
            }
            
            return View(goods);
        }

        public ActionResult Priceless(string price)
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

            return View(good);
        }
    }
}