using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK.DDP.DAL;

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
    }
}
