using System.Web.Http;
using SK.CW.BL;

namespace SK.CW.Web.API
{
    public class UserController : ApiController
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public void Delete(int id)
        {
            _usersService.DeleteUser(id);
        }
    }
}
