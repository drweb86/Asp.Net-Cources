namespace L4HomeWork.DAL
{
    public class Product
    {
        public Product(int product_UID, string name, int price)
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