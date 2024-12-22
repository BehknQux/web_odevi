using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce_app.Migrations
{
    /// <inheritdoc />
    public partial class addSeedDataForProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "A high-end smartphone with 128GB storage.", "Smartphone", 999.99m, 50 },
                    { 2, 1, "A powerful laptop for professionals.", "Laptop", 1499.99m, 30 },
                    { 3, 2, "A professional-grade microscope for science labs.", "Microscope", 499.99m, 20 },
                    { 4, 3, "A wearable fitness tracker to monitor health.", "Fitness Tracker", 199.99m, 100 },
                    { 5, 4, "An online course for advanced mathematics.", "E-Learning Course", 59.99m, 1000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
