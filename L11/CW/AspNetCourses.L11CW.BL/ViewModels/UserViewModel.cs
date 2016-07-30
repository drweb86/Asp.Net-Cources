using System.ComponentModel.DataAnnotations;

namespace AspNetCourses.L11CW.BL.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Login { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string Password { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
