namespace SiarheiKuchukIncorporated.HomeWork8.Bl.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(int category_uid, string name)
        {
            Category_UID = category_uid;
            Name = name;
        }

        public int Category_UID { get; set; }
        public string Name { get; set; }
    }
}