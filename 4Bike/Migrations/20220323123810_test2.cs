using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dcab609-da1c-4f76-b467-28617ad8534a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9dcab609-da1c-4f76-b467-28617ad8534a", "3ceb7862-66fb-447d-a0d8-d0c144648da5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ceb7862-66fb-447d-a0d8-d0c144648da5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcab609-da1c-4f76-b467-28617ad8534a");

            migrationBuilder.DropColumn(
                name: "OrderUserID",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Orders",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_Id",
                table: "Orders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Id",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderUserID",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ceb7862-66fb-447d-a0d8-d0c144648da5", "94d2bf48-f0ad-422d-bbc3-dcd5eafb758c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9dcab609-da1c-4f76-b467-28617ad8534a", "3a8a42dd-871a-4dcb-b903-69cec034f799", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9dcab609-da1c-4f76-b467-28617ad8534a", 0, "Testgatan 20", "460c60c2-9866-4c73-8686-97bf5b455c0b", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEHRmPxlV6HBjnYqOh+CASTHeuC28DpPXzTU1sm/ltuVmgMnc6La/zAQPGIHsI4LgsA==", null, false, "3394ac6e-ccf6-49c1-81cb-827d7aff7084", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "9dcab609-da1c-4f76-b467-28617ad8534a", "3ceb7862-66fb-447d-a0d8-d0c144648da5" });
        }
    }
}
