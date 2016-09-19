using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Security;
using SK.DDP.ViewModels;

namespace SK.DDP.BL
{
    public class UserManagementService: IUserManagementService
    {
        public IEnumerable<UserProfile> GetUsers()
        {
            var result = new List<UserProfile>();

            int totalRecords;
            foreach (MembershipUser dbUer in Membership.GetAllUsers(0, Int32.MaxValue, out totalRecords))
            {
                result.Add(new UserProfile(dbUer.UserName, dbUer.GetPassword(), dbUer.Email));
            }

            return result;
        }

        public UserProfile Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password))
                return null;

            if (!Membership.ValidateUser(login, password))
                return null;

            MembershipUser user = Membership.GetUser(login);

            return new UserProfile(user.UserName, password, user.Email);
        }

        public bool Register(UserProfile newUser, out string error)
        {
            try
            {
                Membership.CreateUser(newUser.Login, newUser.Password, newUser.Email);
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

        public bool Update(UserProfile vm, out string error)
        {
            try
            {
                MembershipUser user = Membership.GetUser(vm.Login);
                user.ChangePassword(user.GetPassword(), vm.Password);
                user.Email = vm.Email;
                Membership.UpdateUser(user);
                error = null;
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public UserProfile GetUser(string userName)
        {
            MembershipUser dbUser = Membership.GetUser(userName);
            if (dbUser == null)
                return null;

            return new UserProfile(dbUser.UserName, dbUser.GetPassword(), dbUser.Email);
        }

        public Guid GetUserKey(string userName)
        {
            MembershipUser dbUser = Membership.GetUser(userName);
            if (dbUser == null)
                throw new ObjectNotFoundException();

            return (Guid)dbUser.ProviderUserKey;
        }
    }
}
