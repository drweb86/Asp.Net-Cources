using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult Index(string lang)
        {
            // TODO: add check if cookie exists etc.
            HttpCookie langCookie = new HttpCookie("lang");
            langCookie.Value = lang;

            Response.Cookies.Add(langCookie);

            return RedirectToAction("Index", "Home");
        }
    }
}