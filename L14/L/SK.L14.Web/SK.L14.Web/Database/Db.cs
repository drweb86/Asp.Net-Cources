using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SK.L14.Web.Database
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
    }

    public class Appointment
    {
        public string Client { get; set; }
        public DateTime Date { get; set; }
    }

    public class Db
    {
        public static List<Appointment> Appointments => new List<Appointment>()
            {
                new Appointment { Client = "Mike", Date=DateTime.Parse("21/6/2016")},
                new Appointment { Client = "Mike", Date=DateTime.Parse("21/6/2016")},
                new Appointment { Client = "Mike", Date=DateTime.Parse("21/6/2016")},
                new Appointment { Client = "Mike", Date=DateTime.Parse("21/6/2016")},
                new Appointment { Client = "Joe", Date=DateTime.Parse("21/6/2016")},
                new Appointment { Client = "Mike", Date=DateTime.Parse("21/6/2016")},
                new Appointment { Client = "Mike", Date=DateTime.Parse("21/6/2016")},
            };

        public static List<Car> Cars => new List<Car>()
            {
                new Car { Color = "Green", Model="Toyota"},
                new Car { Color = "Yellow", Model="Lada"},
                new Car { Color = "Yellow", Model="Proto"}
            };
    }
}