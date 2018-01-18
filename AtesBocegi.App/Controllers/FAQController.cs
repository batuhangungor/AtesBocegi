using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AtesBocegi.App.Controllers
{
    public class FAQController : BaseController
    {
        public IActionResult Index()
        {
            return View(db.FAQ.Where(q=> q.IsVisible).OrderBy(q=> q.ScreenOrder).ToList());
        }
    }
}