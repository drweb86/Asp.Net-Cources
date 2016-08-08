using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademy.Gallery.Dal
{
    public interface IContext
    {
        List<Photo> GetPhotos();
    }
}
