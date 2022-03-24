using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class refreshdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89b5413b-0e6b-485f-89f6-2f2a4c40ced1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "89b5413b-0e6b-485f-89f6-2f2a4c40ced1", "d181c406-1681-46a9-994d-ad26679ba919" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d181c406-1681-46a9-994d-ad26679ba919");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89b5413b-0e6b-485f-89f6-2f2a4c40ced1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3fe74a4-ed94-4164-b954-2f2bc5c56c69", "7691f131-2870-45d4-8bf6-aea00d51120a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d070696b-bc00-4c1e-841d-42929646407a", "eaf24834-ee0d-4e95-9518-28949f2f9e02", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d070696b-bc00-4c1e-841d-42929646407a", 0, "Testgatan 20", "507f2983-d7f9-450a-806c-5045fc6b108c", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIP6ROad0xD3sBoy+qRzqkt48tek4DzsCCLWaL/043Jq9u5cYdhLN2FqdsgxCZUvBg==", null, false, "09deec4d-4c87-433c-ae6d-3f598a73a990", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d070696b-bc00-4c1e-841d-42929646407a", "a3fe74a4-ed94-4164-b954-2f2bc5c56c69" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d070696b-bc00-4c1e-841d-42929646407a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d070696b-bc00-4c1e-841d-42929646407a", "a3fe74a4-ed94-4164-b954-2f2bc5c56c69" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3fe74a4-ed94-4164-b954-2f2bc5c56c69");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d070696b-bc00-4c1e-841d-42929646407a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d181c406-1681-46a9-994d-ad26679ba919", "6f87ea4e-1dfd-4c4e-9ba0-16e6db95c1f6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89b5413b-0e6b-485f-89f6-2f2a4c40ced1", "34d44e4f-082a-4a45-bf9c-ce830f749ffc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "89b5413b-0e6b-485f-89f6-2f2a4c40ced1", 0, "Testgatan 20", "4b3bf00b-25fc-4f63-9316-4ebd9a23423d", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEFX51UBbUcm8e8Wwj9rgjhZNEI8t4stz63nO3wouK45h1Od6jRGp8sLUuU4FqwM4ow==", null, false, "aa041d55-8734-450b-aa10-a88dc3e4dfd8", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "89b5413b-0e6b-485f-89f6-2f2a4c40ced1", "d181c406-1681-46a9-994d-ad26679ba919" });
        }
    }
}
