using System;
using System.Web.Mvc;
using SK.HW16.BL.Services;
using SK.HW16.ViewModels;
using SK.HW16.Web.Models;

namespace SK.HW16.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoService _photoService = new PhotoService();

        [HttpPost]
        public ActionResult AddComment(int id, string comment)
        {
            _photoService.AddComment(new CommentViewModel() {CommentBody = comment, Image_UID = id, TimeStamp = DateTime.UtcNow});

            return RedirectToAction("Index", new {id});
        }

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