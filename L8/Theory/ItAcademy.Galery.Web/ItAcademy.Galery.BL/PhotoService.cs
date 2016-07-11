using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItAcademy.Galery.ViewModels;
using ItAcademy.Gallery.DAL;

namespace ItAcademy.Galery.BL
{
    public class PhotoService
    {
        public List<PhotoViewModel> GetPhotos()
        {
            using (var dbContext = new GalleryEntities())
            {
                return dbContext.Photo
                    .Select(photo=>new PhotoViewModel() {Id = photo.Id, Name = photo.Name, Url = photo.URL})
                    .ToList();
            }
        }
    }
}
