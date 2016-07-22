using System;
using System.Web;
using AspNetCourses.L9.BL.ViewModels;

namespace AspNetCourses.L9.Web.Helpers
{
    public static class CultureCookieHelper
    {
        private const string CookieName = "Supersite-Culture";

        private const string Culture = "Culture";

        public static void Expire(HttpResponseBase response)
        {
            var cookie = response.Cookies[CookieName];
            if (cookie == null)
                return;

            cookie.Expires = DateTime.Now.AddDays(-1);
        }

        public static void Save(HttpResponseBase response, string culture)
        {
            var cookie = new HttpCookie(CookieName);
            cookie.Expires = DateTime.Now.AddDays(3);

            cookie.Values[Culture] = culture;
            cookie.Domain = "localhost";
            cookie.Path = "/";

            if (response.Cookies[CookieName] != null)
                response.Cookies.Remove(CookieName);
            response.Cookies.Add(cookie);
        }

        public static string Load(HttpRequestBase request, string defaultCulture="EN")
        {
            var cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie == null ||
                string.IsNullOrEmpty(cookie.Values[Culture]))
                return defaultCulture;

            return cookie.Values[Culture];
        }
    }
}