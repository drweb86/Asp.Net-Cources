using System.Web.Http;
using SK.CW.BL;
using SK.CW.ViewModels;

namespace SK.CW.Web.API
{
    public class UserDetailsController : ApiController
    {
        /*// GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        
        public DetailViewModel Get(int id)
        {
            var usersService = new UsersService();

            return usersService.GetDetail(id);
        }

        /*
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }*/
    }
}