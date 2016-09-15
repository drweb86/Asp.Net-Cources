using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SK.DDP.ViewModels
{
    public class UserProfile : UserViewModel
    {
        public UserProfile()
        {
        }

        public UserProfile(string login, string password, string email) :
            base(login, password)
        {
            Email = email;
        }

        [DisplayName("E-mail")]
        [Required]
        public string Email { get; set; }
    }
}