using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Models;
using Microsoft.AspNetCore.Http;
using AtesBocegi.Functions;

namespace AtesBocegi.App.Areas.AdminPanel.Controllers
{
    public class GaleryController : BaseAdminPanelController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAlbum()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateAlbum(Album model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                        model.AlbumPhoto = string.Format("data:image/" + image.ContentType + ";base64,{0}", imageBase64Data);
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

            return BadRequest(new
            {
                Message = "ModelState is not valid. Check the ModelState property for specific errors.",
                StatusCode = 400,
                ModelState = ModelState.ToList()
            });
        }
    }
}