using Model.Domain;
using NetProject.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetProject.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IPhotoService _photoService;

        public PhotoController(IAlbumService albumService, IPhotoService photoService) {
            this._albumService = albumService;
            this._photoService = photoService;
        }

        // GET: Photo
        public ActionResult Index(int id)
        {
            return View(_albumService.Get(id));
        }

        [HttpPost]
        public ActionResult Insert(PhotoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { id = model.AlbumId});

            }

           
                var fileName = Path.GetFileName(model.Photo.FileName);

                var fullPath = Path.Combine(Server.MapPath("~/Uploads"), fileName);

                model.Photo.SaveAs(fullPath);


            var photo = new Photo
            {
                AlbumId = model.AlbumId,
                PhotoLink = fileName
            };

            _photoService.Create(photo);


            return RedirectToAction("Index", new { id = model.AlbumId });
        }
    }
}