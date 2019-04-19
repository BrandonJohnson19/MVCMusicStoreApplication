using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        private MVCMusicStoreDB db = new MVCMusicStoreDB();

        public ActionResult Browse()
        {
            return View(db.Genres.ToList());
        }

        public ActionResult Index(int id)
        {
            var albums = GetAlbums(id);
            return View("Index", albums);
        }

        private List<Album> GetAlbums(int searchInt)
        {
            return db.Albums
            .Where(a => a.GenreId.Equals(searchInt))
            .ToList();
        }

        public ActionResult Details(int id)
        {
            Album album = db.Albums.Find(id);
            return View("Details", album);
        }
    }
}