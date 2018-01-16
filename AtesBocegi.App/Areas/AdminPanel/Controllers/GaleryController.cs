using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Models;
using Microsoft.AspNetCore.Http;
using AtesBocegi.Functions;

namespace AtesBocegi.App.Areas.AdminPanel.Controllers
{
    public class GaleryController : BaseAdminPanelController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAlbum()
        {
            return View();
        }
    }
}