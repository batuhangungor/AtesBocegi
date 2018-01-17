using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtesBocegi.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View(db.Article.Where(q=> q.PageName == "Ana Sayfa").Include(q=> q.Color).OrderBy(q=> q.ScreenOrder).ToList());
        }
    }
}