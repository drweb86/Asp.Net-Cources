using System.Web;
using System.Web.Security;

namespace SK.DDP.ImageGallery.Helpers
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

        public static bool IsAuthenticated()
        {
            return (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}