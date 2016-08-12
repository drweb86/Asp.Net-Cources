using System.Web.Http;
using SK.CW.BL;
using SK.CW.ViewModels;

namespace SK.CW.Web.API
{
    public class UserDetailsController : ApiController
    {
        public DetailViewModel Get(int id)
        {
            var usersService = new UsersService();

            return usersService.GetDetail(id);
        }
    }
}