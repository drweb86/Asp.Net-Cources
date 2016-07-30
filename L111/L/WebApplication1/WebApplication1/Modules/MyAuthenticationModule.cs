using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modules
{
    // rare: use case: 2 sites (WebForms, etc), single code for authentication.

    public class MyAuthenticationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnAuthenticateRequest;
        }

        private void OnAuthenticateRequest(object sender, EventArgs e)
        {
            //get cookie
            // go to db, check password from cookie
            // if everything is bad, 
            var app = (HttpApplication) sender;
            //app.CompleteRequest();//we can do that if check is not passed.
            app.Context.Response.Write("auth module was there!");
        }

        public void Dispose()
        {
            // TODO: close db connection
        }
    }
}