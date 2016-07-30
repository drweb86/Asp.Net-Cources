using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Handlers;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // Special routes must go upper default.
            // Routes are used for services injection inside web-site.
            //ImageRouteHandler
            routes.MapRoute(
                name: "api",
                url: "api/{id}"
            ).RouteHandler = new ImageRouteHandler();

            routes.MapRoute(
                name: "Special",
                url: "special/{controller}/{action}/{id}",
                defaults: new { controller = "Special", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );// .RoutedHandler = new MvcRouteHandler(); // optional.
            
        }
    }
}
