using System.ComponentModel;

namespace SK.CW.ViewModels
{
    public class UserViewModel
    {
        public int User_UID { get; set; }

        [DisplayName("���")]
        public string Name { get; set; }
        [DisplayName("�������")]
        public string Surname { get; set; }
        [DisplayName("������")]
        public int Details_UID { get; set; }
    }
}