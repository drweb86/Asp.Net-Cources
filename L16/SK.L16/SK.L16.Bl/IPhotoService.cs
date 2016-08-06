using System.Collections.Generic;
using SK.L15.ViewModels;

namespace SK.L16.Bl
{
    public interface IPhotoService
    {
        List<PhotoViewModel> GetPhotos();
    }
}