using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce_app.Migrations
{
    /// <inheritdoc />
    public partial class passwordHashBlocked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "password", "SecurityStamp" },
                values: new object[] { "316287c9-d92e-4fb3-a940-43b16771007a", "Admin123!", "5123b4bd-31fc-4e4d-9810-8796399be639" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "password", "SecurityStamp" },
                values: new object[] { "9e1c5957-b0cc-4c6b-af3e-00db62f2b255", "hamza", "bde53ff9-1465-4eb0-a56b-a176559ee691" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "password", "SecurityStamp" },
                values: new object[] { "6706f628-144e-4e55-90c6-5ab5889c1776", "AQAAAAIAAYagAAAAENBtq8wGHPzr4DNffRYfqhK9bhpSJNPdUlXDOzPE5lsIQq1EKZE+U/e4dM3vCUevgA==", "dd338093-485a-4724-a3c5-0e03e3756e0a" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "password", "SecurityStamp" },
                values: new object[] { "55da8901-4cfe-43de-b290-8865233c1a67", "AQAAAAIAAYagAAAAEIVJissiH7253WaItbFGczl0vZhKAVaYDQ+Ox/BF8HzbkF+4q0nhGzSqmd/0Kf7Upg==", "6c7e1751-907c-4e17-ae88-8ec8f8471dc2" });
        }
    }
}
