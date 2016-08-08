using ITAcademy.Gallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademy.Gallery.Bl
{
    public interface IPhotoService
    {
        List<PhotoViewModel> GetPhotos();
    }
}
