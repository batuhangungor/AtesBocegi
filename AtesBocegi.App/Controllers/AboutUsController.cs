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
            model.Articles = db.Article.Where(q => q.PageName == "Hakkimizda").OrderBy(q => q.ScreenOrder).Include(q=> q.Color).ToList();
            model.AboutUs = db.AboutUs.FirstOrDefault();
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var model = db.Article.Where(q => q.Id == id).Include(q => q.Color).FirstOrDefault();
            return View(model);
        }
    }
}