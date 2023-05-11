using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flutter_runnner.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionsDetails_tbl",
                columns: table => new
                {
                    details_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    map = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionsDetails_tbl", x => x.details_Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionStatscs_tbl",
                columns: table => new
                {
                    stats_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    top_speed = table.Column<float>(type: "real", nullable: false),
                    low_speed = table.Column<float>(type: "real", nullable: false),
                    average_speed = table.Column<float>(type: "real", nullable: false),
                    average_pace = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionStatscs_tbl", x => x.stats_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entries_tbl",
                columns: table => new
                {
                    entry_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    stats_id = table.Column<int>(type: "int", nullable: false),
                    details_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries_tbl", x => x.entry_id);
                    table.ForeignKey(
                        name: "FK_Entries_tbl_SessionStatscs_tbl_stats_id",
                        column: x => x.stats_id,
                        principalTable: "SessionStatscs_tbl",
                        principalColumn: "stats_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_tbl_SessionsDetails_tbl_details_id",
                        column: x => x.details_id,
                        principalTable: "SessionsDetails_tbl",
                        principalColumn: "details_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_tbl_Users_tbl_user_id",
                        column: x => x.user_id,
                        principalTable: "Users_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_tbl_details_id",
                table: "Entries_tbl",
                column: "details_id");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_tbl_stats_id",
                table: "Entries_tbl",
                column: "stats_id");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_tbl_user_id",
                table: "Entries_tbl",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries_tbl");

            migrationBuilder.DropTable(
                name: "SessionStatscs_tbl");

            migrationBuilder.DropTable(
                name: "SessionsDetails_tbl");

            migrationBuilder.DropTable(
                name: "Users_tbl");
        }
    }
}
