using System;
using System.Collections.Generic;
using System.Web.Security;
using AspNetCourses.L9.BL.ViewModels;

namespace AspNetCourses.L9.BL.Services
{
    public class AuthenticationService
    {
        public IEnumerable<UserViewModel> GetUsers()
        {
            var result = new List<UserViewModel>();

            int totalRecords;
            foreach (MembershipUser dbUer in Membership.GetAllUsers(0, Int32.MaxValue, out totalRecords))
            {
                result.Add(new UserViewModel(dbUer.UserName, dbUer.GetPassword()));
            }

            return result;
        }

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

        public bool Register(UserViewModel newUser)
        {
            try
            {
                Membership.CreateUser(newUser.Login, newUser.Password);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(string userName)
        {
            Membership.DeleteUser(userName);
        }
    }
}
