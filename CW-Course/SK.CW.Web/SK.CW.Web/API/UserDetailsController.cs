using System.Web.Http;
using SK.CW.BL;
using SK.CW.ViewModels;

namespace SK.CW.Web.API
{
    public class UserDetailsController : ApiController
    {
        private readonly IUsersService _usersService;

        public UserDetailsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public DetailViewModel Get(int id)
        {
            return _usersService.GetDetail(id);
        }
    }
}