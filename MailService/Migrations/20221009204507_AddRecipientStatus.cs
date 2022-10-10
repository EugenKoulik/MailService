using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailService.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipientStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedMessage",
                table: "EmailsInfo");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "EmailsInfo");

            migrationBuilder.AddColumn<string>(
                name: "FailedMessage",
                table: "Recipients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Recipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedMessage",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Recipients");

            migrationBuilder.AddColumn<string>(
                name: "FailedMessage",
                table: "EmailsInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "EmailsInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
