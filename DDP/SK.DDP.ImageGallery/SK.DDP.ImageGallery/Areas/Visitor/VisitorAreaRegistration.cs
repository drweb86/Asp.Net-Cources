using System.Web.Mvc;

namespace SK.DDP.ImageGallery.Areas.Visitor
{
    public class VisitorAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Visitor";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Visitor_default",
                "Visitor/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SK.DDP.ImageGallery.Areas.Visitor.Controllers" }
            );
        }
    }
}