using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyThunes.Models
{
    public class MyThunesDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}