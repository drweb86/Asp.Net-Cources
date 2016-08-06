using System.Web.Mvc;

namespace WebApp15.Areas.Auction
{
    public class AuctionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Auction";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Auction_default",
                "Auction/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApp15.Areas.Auction.Controllers" }
            );
        }
    }
}