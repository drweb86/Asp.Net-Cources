using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SK.DDP.DAL;

namespace SK.DDP.BL
{
    public class PhotoService : IPhotoService
    {
        private static IMapper _mapper;
        static PhotoService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AlbumViewModel, Album>();
                cfg.CreateMap<Album, AlbumViewModel>();


            });
            _mapper = config.CreateMapper();
        }


        public IEnumerable<AlbumViewModel> GetAlbums(Guid user)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                return dbContext.Album
                    .Where(album => album.User_UID == user)
                    .ToArray()
                    .Select(dbAlbum => _mapper.Map(dbAlbum, new AlbumViewModel()))
                    .ToArray();
            }
        }

        public void RemoveAllData(Guid user)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                var albumsToRemove = dbContext.Album
                    .Where(Album => Album.User_UID == user)
                    .ToArray();

                var imagesToRemove = new List<Image>();
                foreach (var album in albumsToRemove)
                {
                    imagesToRemove
                        .AddRange(dbContext.Image
                        .Where(image => image.Album_UID == album.Album_UID));
                }

                foreach (var image in imagesToRemove)
                {
                    DeleteImageFile(image.Path);
                }

                dbContext.Image.RemoveRange(imagesToRemove);
                dbContext.Album.RemoveRange(albumsToRemove);

                dbContext.SaveChanges();
            }
        }

        public void AddAlbum(AlbumViewModel viewModel)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                dbContext.Album.Add(_mapper.Map(viewModel, new Album()));

                dbContext.SaveChanges();
            }
        }

        public AlbumViewModel GetAlbum(int id)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                return _mapper.Map(
                    dbContext.Album.First(album=>album.Album_UID == id),
                    new AlbumViewModel());
            }
        }

        public void UpdateAlbum(AlbumViewModel viewModel)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                var dbAlbum = dbContext.Album.First(album => album.Album_UID == viewModel.Album_UID);
                _mapper.Map(viewModel, dbAlbum);

                dbContext.SaveChanges();
            }
        }

        public void DeleteAlbum(AlbumViewModel album)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                var albumToRemove = dbContext.Album.First(dbAlbum => dbAlbum.Album_UID == album.Album_UID);
                var imagesToRemove = dbContext.Image.Where(image => image.Album_UID == album.Album_UID);

                foreach (var image in imagesToRemove)
                {
                    DeleteImageFile(image.Path);
                }

                dbContext.Image.RemoveRange(imagesToRemove);
                dbContext.Album.Remove(albumToRemove);

                dbContext.SaveChanges();
            }
        }

        private void DeleteImageFile(string relativePath)
        {
            //TODO: implement after adding upload images staff.
        }
    }
}
