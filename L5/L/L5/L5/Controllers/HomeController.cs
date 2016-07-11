using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L5.DAL;
using L5.Models;

namespace L5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //NHibernate, BLToolkit are obsolete.

            var photos = new List<Photo>();
            using (var dbContext = new PhotoDbDataContext())
            {
                photos = (from photo in dbContext.Photos
                          select photo).ToList();
            }





            var linq2 = new LinqToXml();
            var kak = linq2.GetSongs();

            var linq = new DemoLinq().GetStudents();
            return View(photos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Photo editedPhoto)
        {
            using (var db = new PhotoDbDataContext())
            {
                var existingPhoto = (
                    from photo in db.Photos
                    where photo.Photo_UID == editedPhoto.Photo_UID
                    select photo)
                    .Single();

                existingPhoto.Name = editedPhoto.Name;
                existingPhoto.URL = editedPhoto.URL;

                db.SubmitChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (var db = new PhotoDbDataContext())
            {
                //IQuerible: filtering will be done in database. !!!!!
                //var q = from photo in db.Photos
                //    where photo.Photo_UID == id
                //    select photo;

                return View((
                    from photo in db.Photos
                    where photo.Photo_UID == id
                    select photo)
                    .Single());
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new PhotoDbDataContext())
            {
                var photoToRemove = (
                    from photo in db.Photos
                    where photo.Photo_UID == id
                    select photo)
                    .Single();

                //var photoEdit = db.Photos.Single(p => p.Photo_UID == id);

                db.Photos.DeleteOnSubmit(photoToRemove);

                db.SubmitChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Photo photo)
        {
            using (var db = new PhotoDbDataContext())
            {
                //Stored in the heap.
                db.Photos.InsertOnSubmit(photo);


                db.SubmitChanges();
            }

            return RedirectToAction("Index");
        }
    }
}