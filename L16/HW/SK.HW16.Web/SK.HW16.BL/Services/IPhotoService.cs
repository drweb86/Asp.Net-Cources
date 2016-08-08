using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK.HW16.ViewModels;

namespace SK.HW16.BL.Services
{
    public interface IPhotoService
    {
        ImageViewModel GetImage(int id);
        ImageViewModel GetFirstImage();
        ImageViewModel GetNextImage(ImageViewModel current);
        ImageViewModel GetPreviousImage(ImageViewModel current);

        IEnumerable<CommentViewModel> GetComments(ImageViewModel image);
        void AddComment(CommentViewModel comment);
    }
}
