using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtesBocegi.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtesBocegi.App.Controllers
{
    public class AboutUsController : BaseController
    {
        public IActionResult Index()
        {
            var model = new AboutUsViewModel();
            model.Articles = db.Article.Where(q => q.PageName == "Hakkımızda").OrderBy(q => q.ScreenOrder).Include(q=> q.Color).ToList();
            return View(model);
        }
    }
}