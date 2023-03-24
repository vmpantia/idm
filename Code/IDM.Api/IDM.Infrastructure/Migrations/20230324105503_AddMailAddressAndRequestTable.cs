using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMailAddressAndRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityGroup_TRN",
                table: "SecurityGroup_TRN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityGroup_TRN",
                table: "SecurityGroup_TRN",
                columns: new[] { "RequestID", "Number" });

            migrationBuilder.CreateTable(
                name: "MailAddress_MST",
                columns: table => new
                {
                    MailAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RelationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerType = table.Column<int>(type: "int", nullable: false),
                    MailType = table.Column<int>(type: "int", nullable: false),
                    PrimaryFlag = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAddress_MST", x => new { x.MailAddress, x.RelationID });
                });

            migrationBuilder.CreateTable(
                name: "MailAddress_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerType = table.Column<int>(type: "int", nullable: false),
                    MailType = table.Column<int>(type: "int", nullable: false),
                    PrimaryFlag = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAddress_TRN", x => new { x.RequestID, x.Number });
                });

            migrationBuilder.CreateTable(
                name: "Request_LST",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FunctionID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApproveBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_LST", x => x.RequestID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailAddress_MST");

            migrationBuilder.DropTable(
                name: "MailAddress_TRN");

            migrationBuilder.DropTable(
                name: "Request_LST");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityGroup_TRN",
                table: "SecurityGroup_TRN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityGroup_TRN",
                table: "SecurityGroup_TRN",
                columns: new[] { "RequestID", "Number", "InternalID" });
        }
    }
}
