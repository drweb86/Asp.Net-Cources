using ITAcademy.Gallery.Dal;
using ITAcademy.Gallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademy.Gallery.Bl
{
    public class PhotoService : IPhotoService
    {
        IContext _context;

        public PhotoService(IContext context)
        {
            _context = context;
        }

        public List<PhotoViewModel> GetPhotos()
        {
            //if (user.settings == "call method")
            //{
            //    _context.GetPhotos();
            //}
            //else
            //return null;

            return _context.GetPhotos().Select(
                x => new PhotoViewModel
                {
                    Name = x.Name,
                    Url = x.Url
                }).ToList();
        }
    }
}
