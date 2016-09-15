using System.Collections.Generic;
using SK.DDP.ViewModels;

namespace SK.DDP.BL
{
    public interface IUserManagementService
    {
        IEnumerable<UserProfile> GetUsers();
        UserProfile Authenticate(string login, string password);
        bool Register(UserProfile newUser, out string error);
        void Delete(string userName);
        bool Update(UserProfile vm, out string error);
        UserProfile GetUser(string userName);
    }
}