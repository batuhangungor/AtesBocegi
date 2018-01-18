using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtesBocegi.App.Controllers
{
    public class GaleryController : BaseController
    {
        public IActionResult Index()
        {
            var albumList = db.Album.Include(q=> q.Color).ToList();
            return View(albumList);
        }

        public IActionResult Details(int albumId)
        {
            var album = db.Album.Where(q=> q.Id == albumId).Include(q=> q.Color).Include(q=> q.AlbumItems).FirstOrDefault();
            return View(album);
        }
    }
}