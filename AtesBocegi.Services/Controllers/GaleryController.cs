using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Models;
using Microsoft.AspNetCore.Http;
using AtesBocegi.Functions;

namespace AtesBocegi.Services.Controllers
{
    public class GaleryController : BaseServiceController
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View(db.Album.ToList());
        }
    }
}