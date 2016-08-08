using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProject.Database;
using WebProject.Models;

namespace WebProject.Api
{
    public class CarsController : ApiController
    {
        //either write Get/Post/Put/Delete or add attribute [HttpGet], etc...
        public IEnumerable<Car> Get()
        {
            return Db.Cars;
        }

        public Car Get(int id)
        {
            return Db.Cars.Single(car=>car.Id == id);
        }

        public void Delete(int id)
        {
            Db.Cars.Remove(Db.Cars.Single(car => car.Id == id));
        }

        public int Get(Car car)
        {
            Db.Cars.Add(car);
            car.Id = Db.Cars.Count;

            return car.Id;
        }
    }
}
