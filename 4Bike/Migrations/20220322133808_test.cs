using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations.ProductDb
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BikePicNav",
                table: "Bikes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BikePicNav",
                table: "Bikes");
        }
    }
}
