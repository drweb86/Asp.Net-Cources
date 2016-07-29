using System;
using System.Runtime.Caching;
using System.Web.Mvc;
using SiarheiKuchukIncorporated.HomeWork8.Bl.Services;
using SiarheiKuchukIncorporated.HomeWork8.Bl.ViewModels;


namespace SiarheiKuchukIncorporated.HomeWork8.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopService _shopService = new ShopService();

        //[OutputCache(Duration = 15)]
        public ActionResult GetCategories()
        {
            const string categoriesKey = "Categories";

            if (!MemoryCache.Default.Contains(categoriesKey))
                MemoryCache.Default.Add(
                    categoriesKey, 
                    _shopService.SelectCategories(), 
                    DateTimeOffset.Now.AddSeconds(15));

            return PartialView(MemoryCache.Default[categoriesKey]);
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