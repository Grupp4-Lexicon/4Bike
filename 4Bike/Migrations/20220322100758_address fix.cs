using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class addressfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7c5bb898-2cf5-4e7c-9a70-cfc212e18e4e", "db0c9a9e-fbf5-43f0-a3fc-ee54adaf9d2c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "106b0ba4-10a8-41b6-beb5-f05644988a08", "5fa1b230-0a78-486e-b43c-e2bf2fdfbc9c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "106b0ba4-10a8-41b6-beb5-f05644988a08", 0, "Testgatan 20", "62b3d19d-3013-458e-bf0c-f749f2b6e70c", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELdSYW6ymaoLgPPgWxTOtEQavB4pE155z8S7XA3XVpgBt/yLeQb6A+fUzpbUFnJ2pg==", null, false, "fbf0feb1-2a30-4289-95e1-2df253b01a9e", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "106b0ba4-10a8-41b6-beb5-f05644988a08", "7c5bb898-2cf5-4e7c-9a70-cfc212e18e4e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "106b0ba4-10a8-41b6-beb5-f05644988a08");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "106b0ba4-10a8-41b6-beb5-f05644988a08", "7c5bb898-2cf5-4e7c-9a70-cfc212e18e4e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c5bb898-2cf5-4e7c-9a70-cfc212e18e4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "106b0ba4-10a8-41b6-beb5-f05644988a08");

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
    }
}
