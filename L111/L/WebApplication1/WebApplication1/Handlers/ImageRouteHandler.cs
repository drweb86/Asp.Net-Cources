using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Database;

namespace WebApplication1.Handlers
{
    public class ImageRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ImageHandler(requestContext);

        }
    }

    public class ImageHandler : IHttpHandler
    {
        private readonly RequestContext _requestContext;

        public ImageHandler(RequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        public void ProcessRequest(HttpContext context)
        {
            var id = Convert.ToInt32(context.Request.RequestContext.RouteData.Values["id"]);
            var image = Db.Images.Single(item => item.Id == id);

            context.Response.ContentType = "xml";
            context.Response.Write(string.Format("<ccccccimage ID=\"{0}\" Name=\"{1}\" />", image.Id, image.Name));
        }

        public bool IsReusable { get { return false; } } //Good variant - true.
    }
}