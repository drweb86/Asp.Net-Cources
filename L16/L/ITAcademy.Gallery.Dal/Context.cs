using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademy.Gallery.Dal
{
    public class Context : IContext
    {
        public Context()
        {
        }

        public List<Photo> GetPhotos()
        {
            return new List<Photo> {
                new Photo { Name = "Photo 1", Url = "url" },
                new Photo { Name = "Photo 2", Url = "url" },
                new Photo { Name = "Photo 3", Url = "url" }
            };
        }
    }
}
