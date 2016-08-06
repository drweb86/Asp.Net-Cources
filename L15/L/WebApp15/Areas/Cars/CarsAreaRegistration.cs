using System.Web.Mvc;

namespace WebApp15.Areas.Cars
{
    public class CarsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cars";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Cars_default",
                "Cars/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApp15.Areas.Cars.Controllers" }
            );
        }
    }
}