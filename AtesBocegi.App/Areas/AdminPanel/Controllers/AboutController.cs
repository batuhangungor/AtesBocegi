using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AtesBocegi.App.Areas.AdminPanel.Controllers
{
    public class AboutController : BaseAdminPanelController
    {
        public IActionResult Index()
        {
            return View(db.AboutUs.FirstOrDefault());
        }
    }
}