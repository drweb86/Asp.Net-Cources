using System;
using System.Linq;
using SiarheiKuchuk.Test8.BL.ViewModels;
using SiarheiKuchuk.Test8.DAL;

namespace SiarheiKuchuk.Test8.BL.Services
{
    public class AuthenticationService
    {
        public bool Authenticate(string login, string password)
        {
            return Authenticate(new UserViewModel {Login = login, Password = password});
        }

        public bool Authenticate(UserViewModel user)
        {
            if (user == null)
                return false;

            using (var dbContext = new UsersEntities())
                return dbContext.User.Any(item => 
                    string.Compare(item.Login, user.Login, StringComparison.OrdinalIgnoreCase) == 0 && 
                    item.Password == user.Password);
        }
    }
}