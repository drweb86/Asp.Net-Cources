using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Binders;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //inetmgr.
    //somee.com

        //localization: 1) Google Translate.
                    // 2) divide site to static and dynamic content. Dynamic - comments of users. Static - strings in code/pages.

    public class HomeController : BaseController
    {
        // GET: Home
        //public ActionResult Index([Bind(Include="Name")]User user) //[Bind(Exclude="Name")]User user 
        //public ActionResult Index([ModelBinder(typeof(UserBinder))]User user) //[Bind(Exclude="Name")]User user 
        public ActionResult Index(User user) //[Bind(Exclude="Name")]User user 
        {
            
            //ConfigurationManager.AppSettings["EmailServer"]
            return View(user);
        }
    }
}