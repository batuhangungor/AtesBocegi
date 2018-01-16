using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Models;
using Microsoft.AspNetCore.Http;
using AtesBocegi.Functions;
using AtesBocegi.Models.DataTables;

namespace AtesBocegi.App.Areas.Services.Controllers
{
    public class SliderController : BaseServiceController
    {
        [HttpGet]
        public string Index()
        {
            return "selam";
        }

        [HttpPost]
        public IActionResult Index(DataTablePostModel dataTablePostModel)
        {
            var model = db.Slider.Select(q => new DataTableSliderList
            {
                Id = q.Id,
                Image = q.Image,
                ScreenOrder = q.ScreenOrder
            });

            var Sliders = DataTableProcessor<DataTableSliderList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = Sliders,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult OperateSlider(Slider model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    try
                    {
                        if (image != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                            model.Image = imageBase64Data;
                            db.Add(model);
                            db.SaveChanges();
                            return StatusCode(200, "Eklendi");
                        }
                        else
                        {
                            ModelState.AddModelError(null, "Please Add Image!");
                        }

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError(null, "Error! An error occurred while Slider creating");
                    }
                }
                else
                {
                    var Slider = db.Slider.Where(q => q.Id == model.Id).FirstOrDefault();
                    if (Slider == null)
                    {
                        ModelState.AddModelError(null, "Unknown Request!");
                    }
                    else
                    {
                        if (image != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                            Slider.Image = imageBase64Data;
                        }
                        Slider.ScreenOrder = model.ScreenOrder;
                        db.Update(Slider);
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
        public IActionResult DeleteSlider(int SliderId)
        {
            var Slider = db.Slider.Where(q => q.Id == SliderId).FirstOrDefault();
            if (Slider != null)
            {
                db.Remove(Slider);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }

        [HttpPost]
        public IActionResult GetSlider(int SliderId)
        {
            var Slider = db.Slider.Where(q => q.Id == SliderId).FirstOrDefault();
            if (Slider != null)
            {
                return StatusCode(200, Slider);
            }
            else
            {
                return StatusCode(404, "Page Not Found");
            }
        }
    }
}
