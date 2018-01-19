using AtesBocegi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtesBocegi.Data
{
    public static class DbInit
    {
        public static void SeedData()
        {
            var db = new DAO();
            if (!db.ColorScale.Any())
            {
                var Color = new ColorScale { MainColor = "rgb(185, 10, 10)", SecondColor = "rgb(185, 10, 10)", Name = "Kırmızı", TextColor = "#f3a5a5" };
                db.Add(Color);
                Color = new ColorScale { MainColor = "linear-gradient(rgb(47, 124, 189), rgb(41, 117, 187))", SecondColor = "rgb(30, 161, 212)", Name = "Mavi", TextColor = "#a1d0fc" };
                db.Add(Color);
                Color = new ColorScale { MainColor = "linear-gradient(rgb(238, 93, 0), rgb(237, 92, 2))", SecondColor = "rgb(249, 140, 2)", Name = "Turuncu", TextColor = "#fdda4c" };
                db.Add(Color);
                Color = new ColorScale { MainColor = "linear-gradient(rgb(135, 178, 0), rgb(139, 182, 0))", SecondColor = "rgb(196, 209, 3)", Name = "Yeşil", TextColor = "#f3fa76" };
                db.Add(Color);
                Color = new ColorScale { MainColor = "linear-gradient(rgb(107, 58, 168), rgb(106, 60, 164))", SecondColor = "rgb(137, 88, 200)", Name = "Mor", TextColor = "#d3afff" };
                db.Add(Color);
                Color = new ColorScale { MainColor = "linear-gradient(rgb(107, 58, 168), rgb(106, 60, 164))", SecondColor = "rgb(137, 88, 200)", Name = "Mor", TextColor = "#B59DD4" };
                db.Add(Color);
                Color = new ColorScale { MainColor = "rgb(12, 150, 177)", SecondColor = "rgb(11, 172, 203)", Name = "Turkuaz", TextColor = "#71e8ff" };
                db.Add(Color);
                db.SaveChanges();
            }
            if(!db.AboutUs.Any())
            {
                var aboutUs = new AboutUs
                {
                    Image = null,
                    LeftContent = "Sol içerik",
                    LeftTitle = "Sol başlık",
                    RightTitle = "Sağ başlık",
                    Mission = "Misyonumuz",
                    Vision = "Vizyonumuz"
                };
                db.Add(aboutUs);
                db.SaveChanges();
            }
        }
    }
}
