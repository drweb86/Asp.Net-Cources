using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SK.HW16.Dal;
using SK.HW16.ViewModels;

namespace SK.HW16.BL.Services
{
    public class PhotoService : IPhotoService
    {
        private static IMapper _mapper;
        static PhotoService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ImageViewModel, Image>();
                cfg.CreateMap<Image, ImageViewModel>();

                cfg.CreateMap<CommentViewModel, Comment>();
                cfg.CreateMap<Comment, CommentViewModel>();
            });
            _mapper = config.CreateMapper();
        }

        public ImageViewModel GetImage(int id)
        {
            using (var dbContext = new PhotosDbEntities())
            {
                return _mapper.Map(
                    dbContext.Images.First(item => item.Image_UID == id), 
                    new ImageViewModel());
            }
        }

        public ImageViewModel GetFirstImage()
        {
            using (var dbContext = new PhotosDbEntities())
            {
                var dbImage = dbContext.Images
                    .OrderBy(item => item.Timestamp)
                    .FirstOrDefault();

                if (dbImage == null)
                    return null;

                return _mapper.Map(dbImage, new ImageViewModel());
            }
        }

        public ImageViewModel GetNextImage(ImageViewModel current)
        {
            using (var dbContext = new PhotosDbEntities())
            {
                var dbImage = dbContext.Images
                    .OrderBy(item => current.Timestamp)
                    .FirstOrDefault(item=> 
                        item.Timestamp >= current.Timestamp &&
                        item.Image_UID != current.Image_UID);

                if (dbImage == null)
                    return null;

                return _mapper.Map(dbImage, new ImageViewModel());
            }
        }

        public ImageViewModel GetPreviousImage(ImageViewModel current)
        {
            using (var dbContext = new PhotosDbEntities())
            {
                var dbImage = dbContext.Images
                    .OrderByDescending(item => current.Timestamp)
                    .FirstOrDefault(item =>
                        item.Timestamp >= current.Timestamp &&
                        item.Image_UID != current.Image_UID);

                if (dbImage == null)
                    return null;

                return _mapper.Map(dbImage, new ImageViewModel());
            }
        }

        public IEnumerable<CommentViewModel> GetComments(ImageViewModel image)
        {
            using (var dbContext = new PhotosDbEntities())
            {
                return dbContext.Comments
                    .Where(item=>item.Image_UID == image.Image_UID)
                    .OrderBy(item => item.TimeStamp)
                    .ToArray()
                    .Select(dbComment => _mapper.Map(dbComment, new CommentViewModel()));
            }
        }

        public void AddComment(CommentViewModel comment)
        {
            using (var dbContext = new PhotosDbEntities())
            {
                dbContext.Comments.Add(_mapper.Map(comment, new Comment()));
                dbContext.SaveChanges();
            }
        }
    }
}
