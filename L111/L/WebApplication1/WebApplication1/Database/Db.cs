using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Database
{
    public static class Db
    {
        public static List<Image> Images = new List<Image>();

        static Db()
        {
            Images.AddRange(new []
            {
                new Image() {Id = 1, Name="First image"},
                new Image() {Id = 2, Name="Second image"},
                new Image() {Id = 3, Name="Third image"},
            });
        }
    }
}