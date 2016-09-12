using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK.DDP.DAL;

namespace SK.DDP.BL
{
    public class PhotoService : IPhotoService
    {
        public void RemoveAllData(Guid user)
        {
            using (var dbContext = new ImageGalleryDbEntities())
            {
                var imagesToRemove = dbContext.Image
                    .Where(image => image.User_UID == user)
                    .ToArray();

                foreach (var image in imagesToRemove)
                {
                    DeleteImageFile(image.Path);
                }

                dbContext.Image.RemoveRange(imagesToRemove);

                dbContext.SaveChanges();
            }
        }

        private void DeleteImageFile(string relativePath)
        {
            //TODO: implement after adding upload images staff.
        }
    }
}
