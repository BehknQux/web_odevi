using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce_app.Migrations
{
    /// <inheritdoc />
    public partial class accountUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3328332-0462-456c-986e-ab6d47388839", "AQAAAAIAAYagAAAAEB7QZj0l5oi8wGvdoKh2oyrbGzzm/u8gFxdr5MYAPCQZfK1T4D/V4t2Qe8uqglQ30w==", "815565cf-5299-4e87-ba2f-640f53b9f277" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "53591a6e-7cee-4b4e-b3c2-7bf805ccc9cd", "atesgolemi@gmail.com", "ATESGOLEMI@GMAIL.COM", "ATESGOLEMI@GMAIL.COM", "AQAAAAIAAYagAAAAENgKUoFNlTdtLY4dzDzt0yY6cKq+FoW8Ftnw5l5FmWM9uoR5J8kEK2FMUeaTBD83Ew==", "009f8ce9-eeb3-4e3c-9578-4ccbbbf3d724", "atesgolemi@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6775fd6d-b39c-447d-8d09-f062fd0362d0", "AQAAAAIAAYagAAAAEFoaYqNcqqT+BrvoEMtcyDD7c2Q0ef/mVbdmBiDE7GyQJSIlobbOG+UClJO/buw8WA==", "dcf55a56-365f-4cc2-ae62-1e1cc1d27062" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b1e5ee93-3fe0-4cb5-a3a6-7091d0f53f02", "user@user.com", "USER@USER.COM", "USER@USER.COM", "AQAAAAIAAYagAAAAEH4R1yr2PQyZTCy9WIF9Ouv+K5WdmLWaYQLMlb2PgfPkJrkejWHGF0GUGx4GlbJTSQ==", "1108d065-63cc-4895-974a-04ee0f24079c", "user@user.com" });
        }
    }
}
