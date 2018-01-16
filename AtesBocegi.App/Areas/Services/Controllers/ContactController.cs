using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtesBocegi.Functions;
using AtesBocegi.Models;
using AtesBocegi.Models.DataTables;
using Microsoft.AspNetCore.Mvc;

namespace AtesBocegi.App.Areas.Services.Controllers
{
    public class ContactController : BaseServiceController
    {
        [HttpPost]
        public IActionResult Index(DataTablePostModel dataTablePostModel)
        {
            var model = db.Contact.Select(q => new DataTableContactList
            {
                Id = q.Id,
                Sender = q.Sender,
                Subject = q.Subject,
                Date = q.SendDate.ToShortDateString(),
                IsReaded = q.IsReaded
            });

            var Contacts = DataTableProcessor<DataTableContactList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = Contacts,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult GetContact(int Id)
        {
            var Contact = db.Contact.Where(q => q.Id == Id).FirstOrDefault();
            if (Contact != null)
            {
                Contact.IsReaded = true;
                db.SaveChanges();
                return StatusCode(200, Contact);
            }
            else
            {
                return StatusCode(404, "Page Not Found");
            }
        }

        [HttpPost]
        public IActionResult DeleteContact(int Id)
        {
            var Contact = db.Contact.Where(q => q.Id == Id).FirstOrDefault();
            if (Contact != null)
            {
                db.Remove(Contact);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }

    }
}