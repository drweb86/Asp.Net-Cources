using System.Web.Mvc;
using SK.HW16.BL.Services;
using SK.HW16.Web.Models;

namespace SK.HW16.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoService _photoService = new PhotoService();

        // GET: Home
        public ActionResult Index(int? id)
        {
            var currentPhoto = id == null ? 
                _photoService.GetFirstImage() : 
                _photoService.GetImage(id.Value);

            return View(new HomePageViewModel(
                _photoService.GetPreviousImage(currentPhoto),
                currentPhoto,
                _photoService.GetNextImage(currentPhoto),
                _photoService.GetComments(currentPhoto)));
        }
    }
}