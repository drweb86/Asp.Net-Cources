using System.Web.Mvc;
using AspNetCourses.L9.Web.Helpers;

namespace AspNetCourses.L9.Web.Controllers
{
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult ChangeCulture(string culture)
        {
            if (!string.IsNullOrEmpty(culture))
                CultureCookieHelper.Save(Response, culture);

            return RedirectToAction("Index", "Home");
        }
    }
}