using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp15.Models;

namespace WebApp15.Database
{
    public static class DB
    {
        public static List<Car> Cars = 
            new List<Car>();

        static DB()
        {
            Cars.Add(new Car { Id = 1, Model = "Ferrari", Price = "1000$" });
            Cars.Add(new Car { Id = 2, Model = "Porshe", Price = "1500$" });
            Cars.Add(new Car { Id = 3, Model = "Smart", Price = "1800$" });
        }
    }
}