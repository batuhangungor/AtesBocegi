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
                var Color = new ColorScale { MainColor = "kırmızı", SecondColor = "kırmızı", Name = "kırmızı", TextColor = "kırmızı" };
                db.Add(Color);
                Color = new ColorScale { MainColor = "mavi", SecondColor = "mavi", Name = "mavi", TextColor = "mavi" };
                db.Add(Color);
                db.SaveChanges();
            }
        }
    }
}
