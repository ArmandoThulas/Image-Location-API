using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageLocationAPI.Data.DataModels;
using ImageLocationAPI.Service;
using Microsoft.EntityFrameworkCore;

namespace ImageLocationAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<VenueCategory> VenueCategories { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.connectionString);
        }
    }
}
