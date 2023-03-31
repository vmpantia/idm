using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MailType",
                table: "EmailAddress_TRN",
                newName: "EmailType");

            migrationBuilder.RenameColumn(
                name: "MailAddress",
                table: "EmailAddress_TRN",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "MailType",
                table: "EmailAddress_MST",
                newName: "EmailType");

            migrationBuilder.RenameColumn(
                name: "MailAddress",
                table: "EmailAddress_MST",
                newName: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailType",
                table: "EmailAddress_TRN",
                newName: "MailType");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "EmailAddress_TRN",
                newName: "MailAddress");

            migrationBuilder.RenameColumn(
                name: "EmailType",
                table: "EmailAddress_MST",
                newName: "MailType");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "EmailAddress_MST",
                newName: "MailAddress");
        }
    }
}
