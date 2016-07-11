using System.Linq;
using System.Web.Mvc;
using L4HomeWork.DAL;

namespace L4HomeWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetCategories()
        {
            var categories = new ShopDbService()
                .SelectCategories();

            return PartialView(categories);
        }

        // GET: Home
        public ActionResult Index(int? id)
        {
            Category category;
            if (id == null)
                category = new ShopDbService().SelectCategories().FirstOrDefault();
            else
            {
                category = new ShopDbService().SelectCategory(id.Value);

                if (category == null)
                {
                    category = new ShopDbService().SelectCategories().FirstOrDefault();
                }
            }

            if (category == null)
                return View();

            return View(new ShopDbService().SelectProducts(category));
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