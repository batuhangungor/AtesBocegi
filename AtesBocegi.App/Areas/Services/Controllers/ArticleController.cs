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
    public class ArticleController : BaseServiceController
    {
        [HttpGet]
        public string Index()
        {
            return "selam";
        }

        [HttpPost]
        public IActionResult Index(DataTablePostModel dataTablePostModel)
        {
            var model = db.Article.Select(q => new DataTableArticleList
            {
                Id = q.Id,
                Title = q.Title,
                PageName = q.PageName
            });

            var Articles = DataTableProcessor<DataTableArticleList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = Articles,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult Operate(Article model, IFormFile image)
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
                        }
                        db.Add(model);
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
