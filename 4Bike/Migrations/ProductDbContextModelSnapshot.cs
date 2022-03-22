﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _4Bike.Data;

namespace _4Bike.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_4Bike.Models.Products.Product_Bike", b =>
                {
                    b.Property<int>("BikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BikeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BikePrice")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerID")
                        .HasColumnType("int");

                    b.HasKey("BikeID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("_4Bike.Models.Products.Product_BikeOrder", b =>
                {
                    b.Property<int>("BikeOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BikeOrderBikeID")
                        .HasColumnType("int");

                    b.Property<int>("BikeOrderOrderID")
                        .HasColumnType("int");

                    b.Property<int>("BikeOrderQuantity")
                        .HasColumnType("int");

                    b.HasKey("BikeOrderID");

                    b.HasIndex("BikeOrderBikeID");

                    b.HasIndex("BikeOrderOrderID");

                    b.ToTable("BikeOrders");
                });

            modelBuilder.Entity("_4Bike.Models.Products.Product_Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerID");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("_4Bike.Models.Products.Product_Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderHandelCost")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_4Bike.Models.Products.Product_Bike", b =>
                {
                    b.HasOne("_4Bike.Models.Products.Product_Manufacturer", "Manufacturer")
                        .WithMany("ManufacturerProducts")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_4Bike.Models.Products.Product_BikeOrder", b =>
                {
                    b.HasOne("_4Bike.Models.Products.Product_Bike", "BikeOrderBike")
                        .WithMany("Orders")
                        .HasForeignKey("BikeOrderBikeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4Bike.Models.Products.Product_Order", "BikeOrderOrder")
                        .WithMany("Bikes")
                        .HasForeignKey("BikeOrderOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}