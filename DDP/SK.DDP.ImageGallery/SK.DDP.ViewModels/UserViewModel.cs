using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SK.DDP.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(string login, string password)
        {
            Login = login;
            Password = password;
        }

        [DisplayName("Username")]
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
