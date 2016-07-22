using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCourses.L9.BL.ViewModels;
using AspNetCourses.L9.Dal;

namespace AspNetCourses.L9.BL.Services
{
    public class AuthenticationService
    {
        public UserViewModel Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password))
                return null;

            using (var loginDb = new LoginsDb())
            {
                var matchingUser = loginDb.Users.FirstOrDefault(dbUser =>
                            dbUser.Login == login &&
                            string.Compare(dbUser.Password, password, StringComparison.OrdinalIgnoreCase) == 0);

                if (matchingUser == null)
                    return null;

                return new UserViewModel(matchingUser.Login, matchingUser.Password, matchingUser.Name);
            }
        }

        public bool Register(UserViewModel newUser)
        {
            try
            {
                using (var loginDb = new LoginsDb())
                {
                    loginDb.Users.Add(new Users()
                    {
                        Login = newUser.Login,
                        Name = newUser.Name,
                        Password = newUser.Password
                    });

                    loginDb.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
