using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class initialagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "853a7cc9-75c3-4485-8be5-b7706899bd8d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "853a7cc9-75c3-4485-8be5-b7706899bd8d", "35a0e1f7-02c6-4125-a957-5a580423f71a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35a0e1f7-02c6-4125-a957-5a580423f71a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "853a7cc9-75c3-4485-8be5-b7706899bd8d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "591b9162-a25e-421c-aea3-adfed21acc94", "c47d08e0-a2a1-4a1e-bdbc-c5f3c84d8e3e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "260a1b2c-992c-438d-bf95-07ccd2d6aa10", "13b37acb-6a3d-4c2b-a917-564eabd73da1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "260a1b2c-992c-438d-bf95-07ccd2d6aa10", 0, "Testgatan 20", "d56ad800-2ed0-4ded-8386-a2b12a775e3a", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMerG8hh/PDa4y7+Bwe9umdO2nEIgxvY6PFdh+EX6/0aZ1CG7ZbyD2ueTRmgipkc4w==", null, false, "53c7cf7b-59db-40d0-baa8-da7ca92587ce", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "260a1b2c-992c-438d-bf95-07ccd2d6aa10", "591b9162-a25e-421c-aea3-adfed21acc94" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "260a1b2c-992c-438d-bf95-07ccd2d6aa10");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "260a1b2c-992c-438d-bf95-07ccd2d6aa10", "591b9162-a25e-421c-aea3-adfed21acc94" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "591b9162-a25e-421c-aea3-adfed21acc94");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "260a1b2c-992c-438d-bf95-07ccd2d6aa10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35a0e1f7-02c6-4125-a957-5a580423f71a", "0ce173c7-e514-40ce-a65e-75733109e689", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "853a7cc9-75c3-4485-8be5-b7706899bd8d", "cbe25b3b-533c-4d45-ab7b-020edd6f1e0d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "853a7cc9-75c3-4485-8be5-b7706899bd8d", 0, "Testgatan 20", "45a9af7e-d840-4c89-8708-8129c78b4554", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIu+3mKy0jd/SgePDXnrvQ02G6a2c+ggY9UsOsLoQkPrVKsBR5Yyx8DUZcxT0BeiEA==", null, false, "abdf0b4b-eb94-44cc-af14-4ba865bd8eb7", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "853a7cc9-75c3-4485-8be5-b7706899bd8d", "35a0e1f7-02c6-4125-a957-5a580423f71a" });
        }
    }
}
