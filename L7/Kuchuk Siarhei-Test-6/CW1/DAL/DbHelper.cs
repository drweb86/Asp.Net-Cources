using System;
using System.Linq;

namespace CW1.DAL
{
    internal class DbHelper
    {
        public static double[] Numbers => new[] {12, 1.2, 3};

        public static bool IsAuthenticated(string login, string password)
        {
            return IsAuthenticated(new User() {Login = login, Password = password});
        }

        public static bool IsAuthenticated(User user)
        {
            if (user == null)
                return false;

            using (var dbContext = new LoginsDbDataContext())
            { 
                return dbContext.Users.Any(item => 
                    string.Compare(item.Login, user.Login, StringComparison.OrdinalIgnoreCase) == 0 && 
                    item.Password == user.Password);
            }
        }
    }
}