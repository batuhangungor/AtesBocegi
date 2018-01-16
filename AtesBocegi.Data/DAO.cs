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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3I7VBMV\SQLEXPRESS; Database=AtesBocegiAnaokulu;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
