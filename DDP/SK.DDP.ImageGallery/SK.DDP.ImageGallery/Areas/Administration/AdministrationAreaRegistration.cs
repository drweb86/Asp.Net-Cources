using System.Web.Mvc;

namespace SK.DDP.ImageGallery.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administration";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[]
                    {
                        "SK.DDP.ImageGallery.Areas.Administration.Controllers",
                        "SK.DDP.ImageGallery.Controllers.Shared"
                    }
            );
        }
    }
}