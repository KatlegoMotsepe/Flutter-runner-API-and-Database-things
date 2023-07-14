using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flutter_runnner.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "map",
                table: "SessionsDetails_tbl");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users_tbl",
                newName: "id");

            migrationBuilder.AddColumn<bool>(
                name: "ForgotPassword",
                table: "Users_tbl",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users_tbl",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users_tbl",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<float>(
                name: "distance",
                table: "SessionsDetails_tbl",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<double>(
                name: "points",
                table: "SessionsDetails_tbl",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgotPassword",
                table: "Users_tbl");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users_tbl");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users_tbl");

            migrationBuilder.DropColumn(
                name: "distance",
                table: "SessionsDetails_tbl");

            migrationBuilder.DropColumn(
                name: "points",
                table: "SessionsDetails_tbl");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users_tbl",
                newName: "Id");

            migrationBuilder.AddColumn<byte[]>(
                name: "map",
                table: "SessionsDetails_tbl",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
