using System;
using System.Web;
using AspNetCourses.L9.BL.ViewModels;

namespace AspNetCourses.L9.Web.Helpers
{
    public static class CredentialsCookieHelper
    {
        private const string CookieName = "Supersite";

        private const string Login = "Login";
        private const string Password = "Password";
        private const string Name = "Name";

        public static void Expire(HttpResponseBase response)
        {
            var cookie = response.Cookies[CookieName];
            if (cookie == null)
                return;

            cookie.Expires = DateTime.Now.AddDays(-1);
        }

        public static void Save(HttpResponseBase response, UserViewModel vm)
        {
            var cookie = new HttpCookie(CookieName);
            cookie.Expires = DateTime.Now.AddDays(3);

            cookie.Values[Login] = vm.Login;
            cookie.Values[Password] = vm.Password;
            cookie.Values[Name] = vm.Name;
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
                string.IsNullOrEmpty(cookie.Values[Login]) ||
                string.IsNullOrEmpty(cookie.Values[Password]) ||
                string.IsNullOrEmpty(cookie.Values[Name]))
                return null;

            return new UserViewModel(
                cookie.Values[Login],
                cookie.Values[Password],
                cookie.Values[Name]);
        }

    }
}