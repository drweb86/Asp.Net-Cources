using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK.L16.Dal
{
    public interface IContext
    {
        List<Photo> GetPhotos();
    }

    public class Photo
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Context : IContext
    {
        public List<Photo> GetPhotos()
        {
            return new List<Photo>() {
                new Photo { Name="SuperKaka1", Url="Kaka1"},
                new Photo { Name="SuperKaka2", Url="Kaka2"}
            };

        }
    }
}
