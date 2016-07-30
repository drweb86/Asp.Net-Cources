using System.Web.Security;
using AspNetCourses.L11CW.BL.ViewModels;

namespace AspNetCourses.L11CW.BL.Services
{
    public class AuthenticationService
    {
        public UserViewModel Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password))
                return null;
           
            if (!Membership.ValidateUser(login, password))
                return null;

            MembershipUser user = Membership.GetUser(login);

            return new UserViewModel(user.UserName, password);
        }

        public UserViewModel GetUser(string userName)
        {
            MembershipUser dbUser = Membership.GetUser(userName);
            return new UserViewModel(dbUser.UserName, dbUser.GetPassword());
        }
    }
}
