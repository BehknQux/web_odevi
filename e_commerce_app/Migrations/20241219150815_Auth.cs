using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce_app.Migrations
{
    /// <inheritdoc />
    public partial class Auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "6775fd6d-b39c-447d-8d09-f062fd0362d0", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEFoaYqNcqqT+BrvoEMtcyDD7c2Q0ef/mVbdmBiDE7GyQJSIlobbOG+UClJO/buw8WA==", null, false, "dcf55a56-365f-4cc2-ae62-1e1cc1d27062", false, "admin@admin.com" },
                    { "2", 0, "b1e5ee93-3fe0-4cb5-a3a6-7091d0f53f02", "user@user.com", true, false, null, "USER@USER.COM", "USER@USER.COM", "AQAAAAIAAYagAAAAEH4R1yr2PQyZTCy9WIF9Ouv+K5WdmLWaYQLMlb2PgfPkJrkejWHGF0GUGx4GlbJTSQ==", null, false, "1108d065-63cc-4895-974a-04ee0f24079c", false, "user@user.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
