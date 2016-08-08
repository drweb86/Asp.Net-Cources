using System.Collections.Generic;
using SK.HW16.ViewModels;

namespace SK.HW16.Web.Models
{
    public class HomePageViewModel
    {
        public ImageViewModel Previous { get; set; }
        public ImageViewModel Current { get; set; }
        public ImageViewModel Next { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
        
        public HomePageViewModel(
            ImageViewModel previous,
            ImageViewModel current,
            ImageViewModel next,
            IEnumerable<CommentViewModel> comments)
        {
            Previous = previous;
            Current = current;
            Next = next;
            Comments = comments;
        }
    }
}