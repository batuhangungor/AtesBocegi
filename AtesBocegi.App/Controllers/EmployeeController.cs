using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtesBocegi.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtesBocegi.App.Controllers
{
    public class EmployeeController : BaseController
    {
        public IActionResult Index()
        {
            return View(db.Employee.OrderBy(q=> q.ScreenOrder).Include(q=> q.Color).ToList());
        }

        public IActionResult Detail()
        {
            return View(db.Employee.OrderBy(q => q.ScreenOrder).Include(q => q.Color).ToList());
        }
    }
}