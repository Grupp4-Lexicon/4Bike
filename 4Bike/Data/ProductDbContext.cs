using _4Bike.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Product_Bike> Bikes { get; set; }
        public DbSet<Product_Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Manufacturer>().HasKey(pm => new { pm.ManufacturerID });

            modelBuilder.Entity<Product_Manufacturer>()
                .HasMany<Product_Bike>(pm => pm.ManufacturerProducts)
                .WithOne(pb => pb.Manufacturer)
                .HasForeignKey(pm => pm.BikeID);

            modelBuilder.Entity<Product_Bike>().HasKey(pb => new { pb.BikeID });

            modelBuilder.Entity<Product_Bike>()
                .HasOne<Product_Manufacturer>(pb => pb.Manufacturer)
                .WithMany(pm => pm.ManufacturerProducts)
                .HasForeignKey(pb => pb.ManufacturerID);
        }
    }
}
