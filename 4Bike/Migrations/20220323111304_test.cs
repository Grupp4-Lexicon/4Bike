using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Bike.Migrations
{
    public partial class test : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "OrderUserID",
                table: "Orders",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
