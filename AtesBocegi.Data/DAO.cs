using AtesBocegi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AtesBocegi.Data
{
    public class DAO : DbContext
    {
        public DbSet<AlbumItem> albumItem { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<ColorScale> ColorScale { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=JOINTDEV01; Database=AtesBocegiAnaokulu;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=185.136.84.150;Database=AtesBocegiAnaokulu;User Id=Jarlexi07;Password=Jarlexi07!-*;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
