using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce_app.Migrations
{
    /// <inheritdoc />
    public partial class columnNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "318fe1d6-7535-4eef-8a7f-e75bd2b79441", "AQAAAAIAAYagAAAAEJKaAwjO1I9XN4qoDD954EPKLMu2ylab+3CK+fl83y9yEw+3MBCk5ht9NjPW15k59g==", "b9abad2d-b8cf-4119-b9f1-05417c779233" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba869e85-1741-488a-bf47-4b93ac93b147", "AQAAAAIAAYagAAAAELliytHhWW960GkfUM6UuGPg7p/A1EKeP3d23kVabD2ConifWy3DuEtrMUJkzrjkJA==", "6fc4e338-4390-4918-9e76-3a90ea05e5a3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af9e33ce-b61d-4899-8ab8-e46b592ba83d", "AQAAAAIAAYagAAAAEHVfJnlbchdDNdOZ+6XqVxn1VKjqBzagNrYg4oIIbQoUfcHihZZZ02hp6x3T59eLaw==", "b672bbc2-92a7-4f56-9c46-9840dec2483e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77a81435-2bf5-4314-9b3c-311c991affd4", "AQAAAAIAAYagAAAAEC/mV3vNJzOr0QpFVg7DzkLfXK3CeGgQlA+DqTVfSH8VKhbtcuK6derC3vvRoXwnCA==", "48529a44-4c0a-4fec-8d34-e11d0469651d" });
        }
    }
}
