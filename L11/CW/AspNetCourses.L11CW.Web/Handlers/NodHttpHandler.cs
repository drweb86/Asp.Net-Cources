using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;
using AspNetCourses.L11CW.BL.Services;

namespace AspNetCourses.L11CW.Web.Handlers
{
    public class NodHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var routeValues = context.Request.RequestContext.RouteData.Values;
            var a = int.Parse(routeValues["a"].ToString());
            var b = int.Parse(routeValues["b"].ToString());

            context.Response.Write(MathHelper.GetNOD(a, b));
        }

        public bool IsReusable => true;
    }
}