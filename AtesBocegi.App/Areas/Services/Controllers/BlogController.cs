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
    public class BlogController : BaseServiceController
    {
        [HttpGet]
        public string Index()
        {
            return "selam";
        }

        [HttpPost]
        public IActionResult Index(DataTablePostModel dataTablePostModel)
        {
            var model = db.Blog.Select(q => new DataTableBlogList
            {
                Id = q.Id,
                Title = q.Title
            });

            var Blogs = DataTableProcessor<DataTableBlogList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = Blogs,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult Operate(Blog model, IFormFile simage, IFormFile bimage)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    try
                    {
                        if (simage == null || bimage == null)
                        {
                            ModelState.AddModelError("error", "Lütfen Resim Ekleyiniz!");
                        }
                        else
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(simage);
                            model.SmallImage = imageBase64Data;
                            imageBase64Data = ImageOperations.GetBase64FromFile(bimage);
                            model.BigImage = imageBase64Data;
                            db.Add(model);
                            db.SaveChanges();
                            return StatusCode(200, "Eklendi");
                        }


                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("error", "Error! An error occurred while album creating");
                    }
                }
                else
                {
                    var blog = db.Blog.Where(q => q.Id == model.Id).FirstOrDefault();
                    if (blog == null)
                    {
                        ModelState.AddModelError("error", "Unknown Request!");
                    }
                    else
                    {
                        if (simage != null )
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(simage);
                            blog.SmallImage = imageBase64Data;
                        }
                        if (bimage != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(bimage);
                            blog.BigImage = imageBase64Data;
                        }
                        blog.ColorId = model.ColorId;
                        blog.Detail = model.Detail;
                        blog.info = model.info;
                        blog.Title = model.Title;
                        db.Update(blog);
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
        public IActionResult DeleteArticle(int blogId)
        {
            var blog = db.Blog.Where(q => q.Id == blogId).FirstOrDefault();
            if (blog != null)
            {
                db.Remove(blog);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }

    }
}
