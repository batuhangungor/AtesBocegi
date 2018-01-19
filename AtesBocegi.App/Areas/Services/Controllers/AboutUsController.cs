using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Models;
using Microsoft.AspNetCore.Http;
using AtesBocegi.Functions;
using AtesBocegi.Models.DataTables;
using AtesBocegi.Models.FormModels;

namespace AtesBocegi.App.Areas.Services.Controllers
{
    public class AboutUsController : BaseServiceController
    {
        [HttpGet]
        public string Index()
        {
            return "selam";
        }

        [HttpPost]
        public IActionResult Index(AboutUs model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                        model.Image = imageBase64Data;
                    }
                    db.Update(model);
                    db.SaveChanges();
                    return StatusCode(200, "Güncellendi");


                }
                catch (Exception e)
                {
                    ModelState.AddModelError("error", "Error! An error occurred while album creating");
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
        public IActionResult Operate(ArticleFormModel model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0 || model.Id == null)
                {
                    try
                    {
                        if (image != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                            model.Image = imageBase64Data;
                        }
                        Article article = new Article
                        {
                            ColorId = model.ColorId,
                            Detail = model.Detail,
                            Image = model.Image,
                            LongDetail = model.LongDetail,
                            PageName = model.PageName,
                            ScreenOrder = model.ScreenOrder,
                            SubTitle = model.SubTitle,
                            Title = model.Title
                        };

                        db.Add(article);
                        db.SaveChanges();
                        return StatusCode(200, "Eklendi");


                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("error", "Error! An error occurred while album creating");
                    }
                }
                else
                {
                    var article = db.Article.Where(q => q.Id == model.Id).FirstOrDefault();
                    if (article == null)
                    {
                        ModelState.AddModelError("error", "Unknown Request!");
                    }
                    else
                    {
                        if (image != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                            article.Image = imageBase64Data;
                        }
                        article.Title = model.Title;
                        article.SubTitle = model.SubTitle;
                        article.ScreenOrder = model.ScreenOrder;
                        article.PageName = model.PageName;
                        article.LongDetail = model.LongDetail;
                        article.Detail = model.Detail;
                        article.ColorId = model.ColorId;
                        db.Update(article);
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
        public IActionResult DeleteArticle(int articleId)
        {
            var article = db.Article.Where(q => q.Id == articleId).FirstOrDefault();
            if (article != null)
            {
                db.Remove(article);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }

    }
}
