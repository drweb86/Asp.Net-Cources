using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SK.DDP.ViewModels
{
    public class UserProfile : UserViewModel
    {
        public UserProfile()
        {
        }

        public UserProfile(string login, string password, string email, bool isBlocked) :
            base(login, password)
        {
            Email = email;
            IsBlocked = isBlocked;
        }

        [DisplayName("E-mail")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Blocked")]
        public bool IsBlocked { get; set; }
    }
}