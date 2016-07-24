using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sk.Hw11.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add(new Route( //Роутинг сюдой не работает, пришлось через конфиг добавлять.
            //    "GetImage/{PictureName}",
            //    new PicturesRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class PicturesRouteHandler : IRouteHandler
    {
        private readonly PicturesHttpHandler _picturesHttpHttpHandler = new PicturesHttpHandler();

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return _picturesHttpHttpHandler;
        }
    }

    public class PicturesHttpHandler : IHttpHandler
    {
        private readonly string _picturesDirectory;

        public PicturesHttpHandler()
        {
            _picturesDirectory = new DirectoryInfo(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PicturesFolder"])).FullName.TrimEnd('\\', '/');
            var rootDirectory = new DirectoryInfo(HttpContext.Current.Server.MapPath("~")).FullName.TrimEnd('\\', '/');

            if (!_picturesDirectory.StartsWith(rootDirectory))
                throw new ConfigurationErrorsException("'PicturesFolder' setting is invalid. Pictures directory must be a subdirectory of a site.");

        }

        public void ProcessRequest(HttpContext context)
        {
            var pictureRelativePath = context.Request.RawUrl.Substring("/GetImage/".Length);

            //var pictureRelativePath = context.Request.Params["PictureName"];
            var picture = new FileInfo(Path.Combine(_picturesDirectory, pictureRelativePath)).FullName;

            if (!picture.StartsWith(_picturesDirectory))
                throw new ConfigurationErrorsException("'PictureName' value is invalid, it is not resides in pictures directory.");

            context.Response.ContentType = "image/png";

            using (var image = new Bitmap(picture))
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                memoryStream.WriteTo(context.Response.OutputStream);
            }
        }

        public bool IsReusable => true;
    }
}
