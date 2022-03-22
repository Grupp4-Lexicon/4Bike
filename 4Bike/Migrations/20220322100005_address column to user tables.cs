using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class addresscolumntousertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1099d6-7b70-43d5-a1f8-03a35e3150bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8c1099d6-7b70-43d5-a1f8-03a35e3150bb", "3137d381-3482-4255-b9b5-37b544f5d7e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3137d381-3482-4255-b9b5-37b544f5d7e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1099d6-7b70-43d5-a1f8-03a35e3150bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c00d9439-4011-4f7a-ab0b-3d6fe9ad48d1", "8266db18-b30d-43e7-b061-a7a97a9b3c1a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "683eaf76-e3fa-4cee-8a90-5dff654ae55d", "d25184c9-a242-470c-b8f0-eb085f0c10cc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "683eaf76-e3fa-4cee-8a90-5dff654ae55d", 0, null, "f11c38ce-f9c6-4063-9912-f1f7eaf7054a", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGM3TeisgoEmrAk+Fuxbu31eDo5LvECjtFw4ZyjZQKem4h3LcBhYF1GRKGI4owklcw==", null, false, "34960697-222a-4196-92df-5bbcd65c18c6", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "683eaf76-e3fa-4cee-8a90-5dff654ae55d", "c00d9439-4011-4f7a-ab0b-3d6fe9ad48d1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "683eaf76-e3fa-4cee-8a90-5dff654ae55d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "683eaf76-e3fa-4cee-8a90-5dff654ae55d", "c00d9439-4011-4f7a-ab0b-3d6fe9ad48d1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c00d9439-4011-4f7a-ab0b-3d6fe9ad48d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "683eaf76-e3fa-4cee-8a90-5dff654ae55d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3137d381-3482-4255-b9b5-37b544f5d7e1", "950d821e-f97a-449f-a85d-9b2196253cc9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c1099d6-7b70-43d5-a1f8-03a35e3150bb", "cdeefa20-b20b-4c9e-a4bb-948d7a11534b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8c1099d6-7b70-43d5-a1f8-03a35e3150bb", 0, null, "400e8fde-fb75-455a-bcab-b290329ab3b7", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMJeiI1XzsOP9PNba+uXJqWP16id+98RJKOMnc2FjcZ+um9K8GK7F3YnIE9B37QQeg==", null, false, "836383e1-b486-4a56-91bd-9672683520db", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8c1099d6-7b70-43d5-a1f8-03a35e3150bb", "3137d381-3482-4255-b9b5-37b544f5d7e1" });
        }
    }
}
