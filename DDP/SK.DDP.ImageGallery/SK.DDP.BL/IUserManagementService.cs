using System.Collections.Generic;
using SK.DDP.ViewModels;

namespace SK.DDP.BL
{
    public interface IUserManagementService
    {
        IEnumerable<UserViewModel> GetUsers();
        UserViewModel Authenticate(string login, string password);
        bool Register(UserViewModel newUser, out string error);
        void Delete(string userName);
        bool Update(UserViewModel vm, out string error);
        UserViewModel GetUser(string userName);
    }
}