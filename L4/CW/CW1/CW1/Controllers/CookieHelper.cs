using System.Linq;
using CW1.Models;

namespace CW1.Controllers
{
    class CookieHelper
    {
        public const string CookieName = "supersite";
    }

    internal class DbHelper
    {
        public static User[] AllUsers = new[]
        {
            new User("test", "test"),
            new User("test2", "test2")
        };

        public static bool IsAuthenticated(User user)
        {
            return AllUsers.Any(item => item.Login == user.Login && item.Password == user.Password);
        }
    }
}