using System.Collections.Generic;
using SK.DDP.BL;

namespace SK.DDP.ImageGallery.Models
{
    public class AlbumPicturesPageViewModel
    {
        public AlbumViewModel Album { get; }
        public IEnumerable<ImageViewModel> Images { get; }

        public AlbumPicturesPageViewModel(
            AlbumViewModel album,
            IEnumerable<ImageViewModel> images)
        {
            Album = album;
            Images = images;
        }
    }
}