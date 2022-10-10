using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailService.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRecipientName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Recipients",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Recipients",
                newName: "Name");
        }
    }
}
