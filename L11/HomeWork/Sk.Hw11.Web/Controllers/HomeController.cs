using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sk.Hw11.Web.Models;

namespace Sk.Hw11.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var picturesFolder = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["PicturesFolder"])).FullName.TrimEnd('\\', '/');
            var rootDirectory = new DirectoryInfo(Server.MapPath("~")).FullName.TrimEnd('\\', '/');

            if (!picturesFolder.StartsWith(rootDirectory))
                throw new ConfigurationErrorsException("'PicturesFolder' setting is invalid. Pictures directory must be a subdirectory of a site.");

            var pictures = Directory
                    .GetFiles(picturesFolder, "*.png")
                    .Select(item=>item
                        .Substring(picturesFolder.Length)
                        .TrimStart('\\', '/')
                        .Replace(".png", string.Empty));

            return View(new HomeIndexPageViewModel(
                picturesFolder.Substring(rootDirectory.Length).Replace('\\', '/'),
                pictures));
        }
    }
}