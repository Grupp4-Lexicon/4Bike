using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "419995ae-9cb2-44c9-8e78-847843ddf1c4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "419995ae-9cb2-44c9-8e78-847843ddf1c4", "bd7e1eaa-d587-4ab9-9e6e-7f3936505e9a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd7e1eaa-d587-4ab9-9e6e-7f3936505e9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "419995ae-9cb2-44c9-8e78-847843ddf1c4");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "bd7e1eaa-d587-4ab9-9e6e-7f3936505e9a", "3d4f8c55-1b1d-487e-b8dc-f4a9d126c6a1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "419995ae-9cb2-44c9-8e78-847843ddf1c4", "78562529-ccef-4996-a7dd-b03f0ee56483", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "419995ae-9cb2-44c9-8e78-847843ddf1c4", 0, "Testgatan 20", "633fde4a-b510-427e-9bcb-d88bb2bc8b64", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEL1CxQZQRpDyYvD91N48UPRLLYDs8qs1DU6vhC/O/V5mP+QoIFgL6mTIGkToWEVetg==", null, false, "2a9cff7d-af03-4d4b-b672-13e0d99c09e5", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "419995ae-9cb2-44c9-8e78-847843ddf1c4", "bd7e1eaa-d587-4ab9-9e6e-7f3936505e9a" });
        }
    }
}
