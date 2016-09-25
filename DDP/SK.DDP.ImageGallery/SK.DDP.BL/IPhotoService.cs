using System;
using System.Collections.Generic;
using System.Web;

namespace SK.DDP.BL
{
    public interface IPhotoService
    {
        IEnumerable<AlbumViewModel> GetAlbums(Guid user);

        void RemoveAllData(Guid user);

        void AddAlbum(AlbumViewModel album);
        AlbumViewModel GetAlbum(int id);
        void UpdateAlbum(AlbumViewModel album);
        void DeleteAlbum(AlbumViewModel album);

        IEnumerable<ImageViewModel> GetImages(AlbumViewModel album);
        void AddImage(AlbumViewModel album, HttpPostedFileBase image);
        void DeleteImage(ImageViewModel image);
        ImageViewModel GetImage(int imageUid);
    }
}
