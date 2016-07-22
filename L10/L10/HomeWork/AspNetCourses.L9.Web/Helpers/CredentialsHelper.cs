using System.Web;
using System.Web.Security;

namespace AspNetCourses.L9.Web.Helpers
{
    public static class CredentialsHelper
    {
        public static void Forget()
        {
            FormsAuthentication.SignOut();
        }

        public static void RememberAsAuthenticated(string login)
        {
            FormsAuthentication.SetAuthCookie(login, true);
        }

        public static string GetAuthenticatedUserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}