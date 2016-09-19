using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using SK.DDP.BL;
using SK.DDP.ImageGallery.Helpers;

namespace SK.DDP.ImageGallery.Areas.Visitor.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPhotoService _photoService = new PhotoService();
        private readonly IUserManagementService _userManagementService = new UserManagementService();

        public ActionResult Index()
        {
            var id = _userManagementService.GetUserKey(CredentialsHelper.GetAuthenticatedUserName());
            return View(_photoService
                .GetAlbums(id)
                .OrderBy(album=>album.Name));
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

            return RedirectToAction("Index");
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