using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtesBocegi.Functions;
using AtesBocegi.Models;
using AtesBocegi.Models.DataTables;
using AtesBocegi.Models.FormModels;
using Microsoft.AspNetCore.Mvc;

namespace AtesBocegi.App.Areas.Services.Controllers
{
    public class FAQController : BaseServiceController
    {
        [HttpPost]
        public IActionResult Index(DataTablePostModel dataTablePostModel)
        {
            var model = db.FAQ.Select(q => new DataTableFAQList
            {
                Id = q.Id,
                Question = q.Question,
                Answer = q.Answer
            });

            var FAQs = DataTableProcessor<DataTableFAQList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = FAQs,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult GetFAQ(int Id)
        {
            var FAQ = db.FAQ.Where(q => q.Id == Id).FirstOrDefault();
            if (FAQ != null)
            {
                return StatusCode(200, FAQ);
            }
            else
            {
                return StatusCode(404, "Page Not Found");
            }
        }

        [HttpPost]
        public IActionResult OperateFAQ(FAQFormModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0 || model.Id == null)
                {
                    try
                    {
                        FAQ faq = new FAQ()
                        {
                            Answer = model.Answer,
                            IsVisible = model.IsVisible,
                            Question = model.Question,
                            ScreenOrder = model.ScreenOrder
                        };
                        db.Add(faq);
                        db.SaveChanges();
                        return StatusCode(200, "Eklendi");

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("error", "Error! An error occurred while FAQ creating");
                    }
                }
                else
                {
                    var faq = db.FAQ.Where(q => q.Id == model.Id).FirstOrDefault();
                    if (faq == null)
                    {
                        ModelState.AddModelError("error", "Unknown Request!");
                    }
                    else
                    {
                        faq.Question = model.Question;
                        faq.Answer = model.Answer;
                        faq.ScreenOrder = model.ScreenOrder;
                        faq.IsVisible = model.IsVisible;
                        db.Update(faq);
                        db.SaveChanges();
                        return StatusCode(200, "Güncellendi!");
                    }
                }
            }
            return BadRequest(new
            {
                Message = "Some error(s) occurred!",
                StatusCode = 400,
                ModelState = ModelState.ToList()
            });
        }

        [HttpPost]
        public IActionResult DeleteFAQ(int Id)
        {
            var faq = db.FAQ.Where(q => q.Id == Id).FirstOrDefault();
            if (faq != null)
            {
                db.Remove(faq);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }

    }
}