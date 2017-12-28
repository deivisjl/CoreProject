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
    public class HomeController : Controller
    {

        IAlbumService _albumService;

        public HomeController(IAlbumService albumService) {
            this._albumService = albumService;
        }

        public ActionResult Index()
        {
            return View(_albumService.GetAll());
        }

        
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Insert(AlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create",model);
            }

            var fileName = Path.GetFileName(model.Photo.FileName);

            var fullPath = Path.Combine(Server.MapPath("~/Uploads"), fileName);

            model.Photo.SaveAs(fullPath);

            var album = new Album {
                Name = model.Name,
                Description = model.Description,
                PhotoLink = fileName
            };
                
            _albumService.Create(album);


            return RedirectToAction("Index");
        }

    }
}