using System.Web.Mvc;
using Sk.Hw14.Bl.Services;

namespace Sk.Hw14.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopService _shopsService = new ShopService();

        public ActionResult Index()
        {
            return View(_shopsService.GetShops());
        }

        public JsonResult ShopDetail(int id)
        {
            return Json(_shopsService.GetShop(id), JsonRequestBehavior.AllowGet);
        }
    }
}