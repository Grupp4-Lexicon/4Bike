using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea7a191d-4909-4297-a706-62352326d934");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ea7a191d-4909-4297-a706-62352326d934", "2994129b-97c6-43a2-b12b-d78b1e7de80b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2994129b-97c6-43a2-b12b-d78b1e7de80b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea7a191d-4909-4297-a706-62352326d934");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2994129b-97c6-43a2-b12b-d78b1e7de80b", "32defb6e-7d5e-4081-83b4-6f1e23880657", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea7a191d-4909-4297-a706-62352326d934", "d72c3321-4bd0-4526-afb3-d494bd0b800f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea7a191d-4909-4297-a706-62352326d934", 0, "Testgatan 20", "9b82b387-441d-4592-9110-2045fba9d5c2", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAENtcuOaTATMVHEjsWUMmvFqxUlskznUbicbM8K6OoC0qVMfOSEktUKbaO4jOCQoAVw==", null, false, "43d7baa0-8a18-49ac-a780-9aab58df17a2", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ea7a191d-4909-4297-a706-62352326d934", "2994129b-97c6-43a2-b12b-d78b1e7de80b" });
        }
    }
}
