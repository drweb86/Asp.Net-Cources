using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK.CW.ViewModels;

namespace SK.CW.BL
{
    public interface IUsersService
    {
        IEnumerable<UserViewModel> GetUsers();
        DetailViewModel GetDetail(int id);

        void AddUser(UserViewModel user, DetailViewModel detail);

        void DeleteUser(int id);
    }
}
