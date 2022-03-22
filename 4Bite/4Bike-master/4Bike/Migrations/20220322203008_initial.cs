using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59be7a65-239e-423a-a490-2a48f92e6caa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "59be7a65-239e-423a-a490-2a48f92e6caa", "42c10cb8-037a-4ebc-9298-9764363b7804" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42c10cb8-037a-4ebc-9298-9764363b7804");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59be7a65-239e-423a-a490-2a48f92e6caa");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "42c10cb8-037a-4ebc-9298-9764363b7804", "ddb9417b-5582-4bfa-987a-1176b73939e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59be7a65-239e-423a-a490-2a48f92e6caa", "aefde569-f1be-4add-b3fa-b02db4b6a200", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "59be7a65-239e-423a-a490-2a48f92e6caa", 0, "Testgatan 20", "cbc6661e-dd2e-4b71-8cd3-76d07236f1cf", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAENF5kOW+ONijaTsmgfLgpPtR4rDwvR3mZ2jp2zqXub2SPXec0qm0OudlZWpXldPwaQ==", null, false, "8b6a537c-a24d-4898-bdd5-d8e1153f5e98", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "59be7a65-239e-423a-a490-2a48f92e6caa", "42c10cb8-037a-4ebc-9298-9764363b7804" });
        }
    }
}
