using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtesBocegi.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtesBocegi.App.Controllers
{
    public class BlogController : BaseController
    {
        public IActionResult Index()
        {
            return View(db.Blog.Include(q=> q.Color).OrderByDescending(q=> q.Id).ToList());
        }
        public IActionResult Details(int id)
        {
            return View(db.Blog.Where(q=> q.Id == id).Include(q => q.Color).FirstOrDefault());
        }
    }
}