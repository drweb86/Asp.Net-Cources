using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Database
{
    public class Db
    {
        public static List<string> Students;

        static Db()
        {
            Students = new List<string> { "Mike", "John", "Mitia", "Jack", "Ivan" };
        }
    }
}