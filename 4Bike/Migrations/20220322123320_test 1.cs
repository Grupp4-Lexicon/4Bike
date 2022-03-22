using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderHandelCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    BikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikePrice = table.Column<int>(nullable: false),
                    BikeName = table.Column<string>(nullable: true),
                    ManufacturerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.BikeID);
                    table.ForeignKey(
                        name: "FK_Bikes_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BikeOrders",
                columns: table => new
                {
                    BikeOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeOrderQuantity = table.Column<int>(nullable: false),
                    BikeOrderBikeID = table.Column<int>(nullable: false),
                    BikeOrderOrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeOrders", x => x.BikeOrderID);
                    table.ForeignKey(
                        name: "FK_BikeOrders_Bikes_BikeOrderBikeID",
                        column: x => x.BikeOrderBikeID,
                        principalTable: "Bikes",
                        principalColumn: "BikeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BikeOrders_Orders_BikeOrderOrderID",
                        column: x => x.BikeOrderOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikeOrders_BikeOrderBikeID",
                table: "BikeOrders",
                column: "BikeOrderBikeID");

            migrationBuilder.CreateIndex(
                name: "IX_BikeOrders_BikeOrderOrderID",
                table: "BikeOrders",
                column: "BikeOrderOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_ManufacturerID",
                table: "Bikes",
                column: "ManufacturerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeOrders");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
