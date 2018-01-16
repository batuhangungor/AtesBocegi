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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=JOINTDEV01; Database=AtesBocegiAnaokulu;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
