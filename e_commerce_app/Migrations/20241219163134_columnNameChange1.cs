using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce_app.Migrations
{
    /// <inheritdoc />
    public partial class columnNameChange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "password");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "password", "SecurityStamp" },
                values: new object[] { "a4854980-8336-462a-b57e-2b559c4de0b2", "AQAAAAIAAYagAAAAEMpZVMCs/MkB3QhZ61+FzyTcuiubvMDMl/7pDwlwzOGEq2oggeKMG2JRPvqu5nthdQ==", "87045fc2-3dd6-4ad7-af8f-f46ff5493a81" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "password", "SecurityStamp" },
                values: new object[] { "d10e6214-b51d-4d57-aaca-c880dca27a28", "AQAAAAIAAYagAAAAEASSEjDs+OJ4wVzsK5a9jXl2R0LZq+ja34NmoQN8ci1ZlbNHAN1l1btniPFRC7DobA==", "bbe1e015-3970-4cc0-8137-5232e12dc423" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "username");

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
    }
}
