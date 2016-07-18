using System.Web.Mvc;
using SiarheiKuchukIncorporated.HomeWork8.Bl.Services;
using SiarheiKuchukIncorporated.HomeWork8.Bl.ViewModels;


namespace SiarheiKuchukIncorporated.HomeWork8.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopService _shopService = new ShopService();

        public ActionResult GetCategories()
        {
            var categories = _shopService
                .SelectCategories();

            return PartialView(categories);
        }

        // GET: Home
        public ActionResult Index(int? id)
        {
            CategoryViewModel category;
            if (id == null)
                category = _shopService.SelectFirstCategory();
            else
            {
                category = _shopService.SelectCategory(id.Value) ??
                    _shopService.SelectFirstCategory();
            }

            if (category == null)
                return View();

            return View(_shopService.SelectProducts(category));
        }

        public ActionResult Home()
        {
            return View("Index");
        }

        public ActionResult Contacts()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}