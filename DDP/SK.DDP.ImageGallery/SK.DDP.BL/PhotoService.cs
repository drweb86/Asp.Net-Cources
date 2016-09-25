using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
                cfg.CreateMap<ImageViewModel, Image>();
                cfg.CreateMap<Image, ImageViewModel>();
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
                
                dbContext.Image.RemoveRange(imagesToRemove);
                var albumsFolder = FileUtils.GetUserAlbumsFolder(user);
                if (Directory.Exists(albumsFolder))
                    Directory.Delete(albumsFolder, true);

                dbContext.Album.RemoveRange(albumsToRemove);

                dbContext.SaveChanges();
            }
        }

        public void AddAlbum(AlbumViewModel viewModel)
        {
            viewModel.Album_UID = 0;
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

                var albumsFolder = FileUtils.GetUserImagesFolder(albumToRemove.User_UID, albumToRemove.Album_UID);
                if (Directory.Exists(albumsFolder))
                    Directory.Delete(albumsFolder, true);

                dbContext.Image.RemoveRange(imagesToRemove);
                dbContext.Album.Remove(albumToRemove);

                dbContext.SaveChanges();
            }
        }

        public ImageViewModel GetImage(int imageUid)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                return _mapper.Map(
                    dbContext.Image.First(dbImage => dbImage.Image_UID == imageUid),
                    new ImageViewModel());
            }
        }

        public void DeleteImage(ImageViewModel image)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                dbContext.Image.Remove(dbContext.Image.First(dbImage=> dbImage.Image_UID == image.Image_UID));

                dbContext.SaveChanges();
            }
        }

        public IEnumerable<ImageViewModel> GetImages(AlbumViewModel album)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                return dbContext.Image
                    .Where(image => image.Album_UID == album.Album_UID)
                    .ToArray()
                    .Select(dbImage => _mapper.Map(dbImage, new ImageViewModel()))
                    .ToArray();
            }
        }

        public void AddImage(AlbumViewModel album, HttpPostedFileBase image)
        {
            var dbImage = new Image();
            using (var dbContext = new ImageGalleryDbEntities())
            {
                dbImage.Album_UID = album.Album_UID;
                dbImage.Date = DateTime.UtcNow;
                dbImage.Path = Path.GetFileName(image.FileName);

                dbContext.Image.Add(dbImage);

                dbContext.SaveChanges();
            }

            Directory.CreateDirectory(FileUtils.GetImageFolder(album.User_UID, album.Album_UID, dbImage.Image_UID));
            image.SaveAs(FileUtils.GetImagePath(album.User_UID, album.Album_UID, dbImage.Image_UID, dbImage.Path));
        }
    }
}
