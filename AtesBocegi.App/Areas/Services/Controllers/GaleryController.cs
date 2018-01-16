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
    public class GaleryController : BaseServiceController
    {
        [HttpGet]
        public string Index()
        {
            return "selam";
        }

        [HttpPost]
        public IActionResult Index(DataTablePostModel dataTablePostModel)
        {
            var model = db.Album.Select(q => new DataTableAlbumList
            {
                Id = q.Id,
                Name = q.Name
            });

            var Albums = DataTableProcessor<DataTableAlbumList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = Albums,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult OperateAlbum(Album model, IFormFile image)
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
                            model.AlbumPhoto = imageBase64Data;
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
                        ModelState.AddModelError(null, "Error! An error occurred while album creating");
                    }
                }
                else
                {
                    var album = db.Album.Where(q => q.Id == model.Id).FirstOrDefault();
                    if (album == null)
                    {
                        ModelState.AddModelError(null, "Unknown Request!");
                    }
                    else
                    {
                        if (image != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                            album.AlbumPhoto = imageBase64Data;
                        }
                        album.Name = model.Name;
                        album.ColorId = model.ColorId;
                        db.Update(album);
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
        public IActionResult DeleteAlbum(int albumId)
        {
            var album = db.Album.Where(q => q.Id == albumId).FirstOrDefault();
            if (album != null)
            {
                db.Remove(album);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }

        [HttpPost]
        public IActionResult GetAlbum(int albumId)
        {
            var album = db.Album.Where(q => q.Id == albumId).FirstOrDefault();
            if (album != null)
            {
                return StatusCode(200, album);
            }
            else
            {
                return StatusCode(404, "Page Not Found");
            }
        }
    }
}
