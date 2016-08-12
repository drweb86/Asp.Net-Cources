using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SK.CW.ViewModels;

namespace SK.CW.Web.Models
{
    public class AddUserPageViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено.")]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено.")]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [Range(1, 200, ErrorMessage = "Возраст должен быть в диапазоне от 1 до 200")]
        [Required(ErrorMessage = "Поле должно быть заполнено.")]
        [DisplayName("Возраст")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено.")]
        [DisplayName("Адрес")]
        public string Address { get; set; }

        public UserViewModel GetUserViewModel()
        {
            return new UserViewModel {Name= Name, Surname = Surname};
        }

        public DetailViewModel GetDetailViewModel()
        {
            return new DetailViewModel { Age = Age, Address = Address };
        }
    }
}