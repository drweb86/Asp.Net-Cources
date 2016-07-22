using System.ComponentModel.DataAnnotations;

namespace AspNetCourses.L9.BL.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(255, ErrorMessageResourceName = "UserViewModel_LoginLengthExceeds255Chars", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "UserViewModel_Login", ResourceType = typeof(Resources))]
        public string Login { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(255, ErrorMessageResourceName = "UserViewModel_PasswordLengthExceeds255Chars", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "UserViewModel_Password", ResourceType = typeof(Resources))]
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
