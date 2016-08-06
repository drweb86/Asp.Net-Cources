using System.Web.Mvc;

namespace WebApp15.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Forum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Forum_default",
                "Forum/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApp15.Areas.Forum.Controllers" }
            );
        }
    }
}