using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailService.Migrations
{
    /// <inheritdoc />
    public partial class AddLogInf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "EmailsInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FailedMessage",
                table: "EmailsInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "EmailsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipients_EmailsInfo_EmailInfoId",
                        column: x => x.EmailInfoId,
                        principalTable: "EmailsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_EmailInfoId",
                table: "Recipients",
                column: "EmailInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "EmailsInfo");

            migrationBuilder.DropColumn(
                name: "FailedMessage",
                table: "EmailsInfo");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "EmailsInfo");
        }
    }
}
