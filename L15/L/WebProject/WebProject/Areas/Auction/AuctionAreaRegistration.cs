﻿using System.Web.Mvc;

namespace WebProject.Areas.Auction
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
                new { action = "Index", id = UrlParameter.Optional, controller = "Home" },
                new[] { "WebProject.Areas.Auction.Controllers" }
            );
        }
    }
}