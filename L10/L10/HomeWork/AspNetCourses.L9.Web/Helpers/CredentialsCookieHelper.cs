using System;
using System.Web;
using System.Web.Security;
using AspNetCourses.L9.BL.ViewModels;

namespace AspNetCourses.L9.Web.Helpers
{
    public static class CredentialsCookieHelper
    {
        private const string CookieName = "Supersite";

        private const string Login = "Login";

        public static void Expire(HttpResponseBase response)
        {
            FormsAuthentication.SignOut();

            var cookie = response.Cookies[CookieName];
            if (cookie == null)
                return;

            cookie.Expires = DateTime.Now.AddDays(-1);
        }

        public static void Save(HttpResponseBase response, UserViewModel vm)
        {
            FormsAuthentication.SetAuthCookie(vm.Login, true);

            var cookie = new HttpCookie(CookieName);
            cookie.Expires = DateTime.Now.AddDays(3);

            cookie.Values[Login] = vm.Login;
            cookie.Domain = "localhost";
            cookie.Path = "/";

            if (response.Cookies[CookieName] != null)
                response.Cookies.Remove(CookieName);
            response.Cookies.Add(cookie);
        }

        public static UserViewModel Load()
        {
            var cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie == null ||
                string.IsNullOrEmpty(cookie.Values[Login]))
                return null;

            return new UserViewModel(
                cookie.Values[Login],
                null);
        }
    }
}