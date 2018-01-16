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

        [HttpPost]
        public IActionResult Images(DataTablePostModel dataTablePostModel, int albumId)
        {
            var model = db.albumItem.Where(q => q.AlbumId == albumId).Select(q => new DataTableAlbumItemList
            {
                Id = q.Id,
                Image = q.Image
            });

            var Images = DataTableProcessor<DataTableAlbumItemList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = Images,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult GetImage(int imageId)
        {
            var image = db.albumItem.Where(q => q.Id == imageId).FirstOrDefault();
            if (image != null)
            {
                return StatusCode(200, image);
            }
            else
            {
                return StatusCode(404, "Page Not Found");
            }
        }

        [HttpPost]
        public IActionResult DeleteImage(int imageId)
        {
            var image = db.albumItem.Where(q => q.Id == imageId).FirstOrDefault();
            if (image != null)
            {
                db.Remove(image);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }


        [HttpPost]
        public IActionResult OperateImage(IFormFile image,int albumId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        var model = new AlbumItem();
                        string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                        model.Image = imageBase64Data;
                        model.AlbumId = albumId;
                        db.Add(model);
                        db.SaveChanges();
                        return StatusCode(200, "Eklendi");
                    }
                    else
                    {
                        ModelState.AddModelError(null, "Please Add Image!");
                    }

                }
                catch (Exception e)
                {
                    ModelState.AddModelError(null, "Error! An error occurred while Image creating");
                }
            }
            return BadRequest(new
            {
                Message = "Some error(s) occurred!",
                StatusCode = 400,
                ModelState = ModelState.ToList()
            });
        }

    }
}
