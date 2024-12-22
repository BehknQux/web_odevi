using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce_app.Migrations
{
    /// <inheritdoc />
    public partial class tableNameChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Users_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Users_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Users_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_users_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_users_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_users_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_users_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_users_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_users_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_users_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_users_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Users_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Users_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Users_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
