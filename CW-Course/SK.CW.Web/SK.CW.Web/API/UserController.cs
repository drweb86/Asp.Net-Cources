using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SK.CW.BL;

namespace SK.CW.Web.API
{
    public class UserController : ApiController
    {
        public void Delete(int id)
        {
            new UsersService().DeleteUser(id);
        }
    }
}
