namespace SiarheiKuchukIncorporated.HomeWork8.Bl.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(int product_UID, string name, int price)
        {
            Product_UID = product_UID;
            Name = name;
            Price = price;
        }

        public int Product_UID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}