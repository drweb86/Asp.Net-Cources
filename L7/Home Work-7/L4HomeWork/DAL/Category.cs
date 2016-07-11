namespace L4HomeWork.DAL
{
    public class Category
    {
        public Category(int category_uid, string name)
        {
            Category_UID = category_uid;
            Name = name;
        }

        public int Category_UID { get; set; }
        public string Name { get; set; }
    }
}