using SK.L15.ViewModels;
using SK.L16.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK.L16.Bl
{
    public class PhotoService : IPhotoService
    {
        private readonly IContext _context;

        public PhotoService(IContext context)
        {
            _context = context;
        }

        public List<PhotoViewModel> GetPhotos()
        {
            return _context.GetPhotos()
                .Select(photo => new PhotoViewModel() { Name = photo.Name, Url = photo.Url })
                .ToList();
        }
    }
}
