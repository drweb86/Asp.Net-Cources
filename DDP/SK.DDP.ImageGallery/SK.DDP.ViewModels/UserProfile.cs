using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SK.DDP.ViewModels
{
    public class UserProfile : UserViewModel
    {
        public UserProfile()
        {
        }

        public UserProfile(string login, string password) :
            base(login, password)
        {
            Login = login;
            Password = password;
        }

        [DisplayName("E-mail")]
        [Required]
        public string Email { get; set; }
    }
}