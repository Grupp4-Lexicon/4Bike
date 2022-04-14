using System;
using _4Bike.Areas.Identity.Data;
using _4Bike.Models.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4Bike.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product_Bike> Bikes { get; set; }
        public DbSet<Product_Manufacturer> Manufacturers { get; set; }
        public DbSet<Product_Order> Orders { get; set; }
        public DbSet<Product_BikeOrder> BikeOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product_Manufacturer>().HasKey(pm => new { pm.ManufacturerID });

            builder.Entity<Product_Manufacturer>()
                .HasMany<Product_Bike>(pm => pm.ManufacturerProducts)
                .WithOne(pb => pb.Manufacturer)
                .HasForeignKey(pm => pm.BikeID);

            builder.Entity<Product_Bike>().HasKey(pb => new { pb.BikeID });

            builder.Entity<Product_Bike>()
                .HasOne<Product_Manufacturer>(pb => pb.Manufacturer)
                .WithMany(pm => pm.ManufacturerProducts)
                .HasForeignKey(pb => pb.ManufacturerID);

            builder.Entity<Product_Order>().HasKey(po => new { po.OrderID });

            builder.Entity<Product_BikeOrder>().HasKey(pbo => new { pbo.BikeOrderID });

            builder.Entity<Product_BikeOrder>()
                .HasOne<Product_Bike>(pbo => pbo.BikeOrderBike)
                .WithMany(pb => pb.Orders)
                .HasForeignKey(pbo => pbo.BikeOrderBikeID);

            builder.Entity<Product_BikeOrder>()
                .HasOne<Product_Order>(pbo => pbo.BikeOrderOrder)
                .WithMany(po => po.Bikes)
                .HasForeignKey(pbo => pbo.BikeOrderOrderID);

            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //User roles
            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userId,
                Name = "User",
                NormalizedName = "USER"
            });

            //Make pw hasher for seeded users
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            //Seeded users
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "password"),
                FirstName = "Admin",
                LastName = "Adminsson",
                Address = "Testgatan 20"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

        }

        public DbSet<ApplicationUser> Users { get; set; }

    }
}
