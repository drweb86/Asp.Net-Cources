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

        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
