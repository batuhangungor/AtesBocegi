using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AtesBocegi.App.Areas.Services.Controllers
{
    public class ApiProviderController : BaseServiceController
    {
        [HttpPost]
        public IActionResult GetColors()
        {
            var model = db.ColorScale.Select(q => new {
                display = q.Name,
                value = q.Id
            });
            return StatusCode(200, model);
        }

        [HttpPost]
        public IActionResult GetPages()
        {
            List<string> pages = new List<string> {
                "Ana Sayfa",
                "Hakkimizda"
            };

            var model = pages.Select(q => new
            {
                display = q,
                value = q
            });
            return StatusCode(200, model);
        }

        [HttpPost]
        public IActionResult GetRoles()
        {
            List<string> Roles = new List<string> {
                "Müdür",
                "Psikolog",
                "Ogretmen",
                "Personel"
            };

            var model = Roles.Select(q => new
            {
                display = q,
                value = q
            });
            return StatusCode(200, model);
        }
    }
}