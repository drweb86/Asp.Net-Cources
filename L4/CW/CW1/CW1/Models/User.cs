using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW1.Models
{
    public class User
    {
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User()
        {
        }

        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}