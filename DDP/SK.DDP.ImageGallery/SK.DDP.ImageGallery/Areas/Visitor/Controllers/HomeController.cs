using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ImageGallery.Helpers;
using SK.DDP.ImageGallery.Models;

namespace SK.DDP.ImageGallery.Areas.Visitor.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IUserManagementService _userManagementService;

        public HomeController(
            IPhotoService photoService,
            IUserManagementService userManagementService)
        {
            _photoService = photoService;
            _userManagementService = userManagementService;
        }

        public ActionResult Index()
        {
            var id = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            return View(_photoService
                .GetAlbums(id)
                .OrderBy(album=>album.Name));
        }

        public ActionResult DeleteImage(int id)
        {
            var userUid = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            var image = _photoService.GetImage(id);
            var album = _photoService.GetAlbum(image.Album_UID);
            if (album.User_UID != userUid)
                throw new SecurityException($"Attempt by {userUid} to add image to album {album.Album_UID} of different user");

            _photoService.DeleteImage(image);

            return RedirectToAction("ViewAlbum", new { id = album.Album_UID });
        }

        public ActionResult AddAlbum()
        {
            return View(new AlbumViewModel());
        }

        [HttpPost]
        public ActionResult AddAlbum(AlbumViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var id = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            viewModel.User_UID = id;

            _photoService.AddAlbum(viewModel);

            return RedirectToAction("ViewAlbum", new { id = viewModel .Album_UID });
        }

        public ActionResult ViewAlbum(int id)
        {
            var userUid = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            var album = _photoService.GetAlbum(id);
            if (album.User_UID != userUid)
                throw new SecurityException($"Attempt by {userUid} to access album {album.Album_UID} of different user");

            var pageModel = new AlbumPicturesPageViewModel(
                album,
                _photoService.GetImages(album));

            return View(pageModel);
        }

        public ActionResult AddImage(int id)
        {
            var user_uid = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            var album = _photoService.GetAlbum(id);
            if (album.User_UID != user_uid)
                throw new SecurityException($"Attempt by {user_uid} to add image to album {album.Album_UID} of different user");

            return View(new AddImagePageViewModel() { Album = id });
        }

        [HttpPost]
        public ActionResult AddImage(AddImagePageViewModel viewModel)
        {
            var user_uid = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            var album = _photoService.GetAlbum(viewModel.Album);
            if (album.User_UID != user_uid)
                throw new SecurityException($"Attempt by {user_uid} to add image to album {album.Album_UID} of different user");

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _photoService.AddImage(album, viewModel.Image);

            return RedirectToAction("ViewAlbum", new {id = viewModel.Album });
        }

        public ActionResult RenameAlbum(int id)
        {
            var user_uid = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            var album = _photoService.GetAlbum(id);
            if (album.User_UID != user_uid)
                throw new SecurityException($"Attempt by {user_uid} to edit album {album.Album_UID} of different user");

            return View(album);
        }

        [HttpPost]
        public ActionResult RenameAlbum(AlbumViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user_uid = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            var dbAlbum = _photoService.GetAlbum(viewModel.Album_UID);
            if (dbAlbum.User_UID != user_uid)
                throw new SecurityException($"Attempt by {user_uid} to edit album {dbAlbum.Album_UID} of different user");

            _photoService.UpdateAlbum(viewModel);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAlbum(int id)
        {
            var user_uid = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            var dbAlbum = _photoService.GetAlbum(id);
            if (dbAlbum.User_UID != user_uid)
                throw new SecurityException($"Attempt by {user_uid} to edit album {dbAlbum.Album_UID} of different user");

            _photoService.DeleteAlbum(dbAlbum);

            return RedirectToAction("Index");
        }
    }
}