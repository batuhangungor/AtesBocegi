﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Models;
using Microsoft.AspNetCore.Http;
using AtesBocegi.Functions;

namespace AtesBocegi.App.Areas.AdminPanel.Controllers
{
    public class ArticleController : BaseAdminPanelController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Operator(int? id)
        {
            if (id == null)
            {
                ViewBag.title = "Yeni İçerik";
                ViewBag.buttonText = "Ekle";
                return View();
            }
            else
            {
                var model = db.Article.Where(q => q.Id == id).FirstOrDefault();
                if (model == null)
                {
                    //todo
                }
                else
                {
                    ViewBag.title = model.Title + "Güncelle";
                    ViewBag.buttonText = "Güncelle";
                    return View(model);
                }
            }
            return View();
        }
    }
}