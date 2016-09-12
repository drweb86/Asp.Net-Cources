using System;
using System.Collections.Generic;
using System.Web.Security;
using SK.DDP.ViewModels;

namespace SK.DDP.BL
{
    public class UserManagementService: IUserManagementService
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

        public bool Register(UserViewModel newUser, out string error)
        {
            try
            {
                Membership.CreateUser(newUser.Login, newUser.Password);
                error = null;
                return true;
            }
            catch(Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public void Delete(string userName)
        {
            var id = (Guid)Membership.GetUser(userName).ProviderUserKey;

            new PhotoService().RemoveAllData(id);

            Membership.DeleteUser(userName);
        }

        public bool Update(UserViewModel vm, out string error)
        {
            try
            {
                MembershipUser user = Membership.GetUser(vm.Login);
                user.ChangePassword(user.GetPassword(), vm.Password);
                error = null;
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public UserViewModel GetUser(string userName)
        {
            MembershipUser dbUser = Membership.GetUser(userName);
            return new UserViewModel(dbUser.UserName, dbUser.GetPassword());
        }
    }
}
