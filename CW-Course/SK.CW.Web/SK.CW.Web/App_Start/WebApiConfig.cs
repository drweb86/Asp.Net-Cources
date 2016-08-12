using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SK.CW.DI;

namespace SK.CW.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "API/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.DependencyResolver = new AppDependencyResolver();
        }
    }
}