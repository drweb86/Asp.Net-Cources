using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using L10.Models;

namespace L10.Controllers
{
    //C:\Windows\Microsoft.NET\Framework64\v4.0.30319\aspnet_regsql.exe
    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\drweb86\Documents\Asp.Net-Cources\L10\L\L10\L10\App_Data\Shop.mdf;Integrated Security=True


        [Authorize(Roles = "superadmin,admin")]
    public class HomeController : Controller
    {
        //when db is deployed, usually Init method temporary createed
        public void Init()
        {
            Membership.CreateUser("admin", "admi78987698769876n");
            Roles.CreateRole("admin"); //Enums are used in production.
            Roles.CreateRole("superadmin");
            Roles.AddUserToRole("admin", "admin");
        }

        // GET: Home
        //[Authorize(Roles = "superadmin,admin")]
        public ActionResult Index()
        {
            var users = new List<User>();

            //TODO: get users from db
            var provider = Membership.Providers["SqlProvider"];
            // var provider = Membership.Provider;
            int totalRecords;
            var data = provider.GetAllUsers(0, 50, out totalRecords);
            foreach (MembershipUser user in data)
            {
                users.Add(new User {Name = user.UserName, Roles = Roles.GetRolesForUser(user.UserName)});
            }

            return View(users);
        }
    }
}