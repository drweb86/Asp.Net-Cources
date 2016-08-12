using System.ComponentModel;

namespace SK.CW.ViewModels
{
    public class UserViewModel
    {
        public int User_UID { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Детали")]
        public int Details_UID { get; set; }
    }
}