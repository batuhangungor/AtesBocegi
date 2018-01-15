using AtesBocegi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AtesBocegi.Data
{
    public class DAO : DbContext
    {
        public DbSet<AlbumItem> albumItem { get; set; }
        public DbSet<Album> Album { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3I7VBMV\SQLEXPRESS; Database=AtesBocegiAnaokulu;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
