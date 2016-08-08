using System.Collections.Generic;
using WebProject.Models;

namespace WebProject.Database
{
    public static class Db
    {
        public static List<Car> Cars = new List<Car>();

        static Db()
        {
            Cars.Add(new Car { Id = 1, Model = "Ferrari", Price="1000 $"});
            Cars.Add(new Car { Id = 2, Model = "Porshe", Price = "1500 $" });
            Cars.Add(new Car { Id = 3, Model = "Smart", Price = "1800 $" });
        }
    }
}