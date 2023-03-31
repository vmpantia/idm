using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailAddress_MST",
                columns: table => new
                {
                    MailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_EmailAddress_MST", x => x.MailAddress);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_EmailAddress_TRN", x => new { x.RequestID, x.Number });
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

            migrationBuilder.CreateTable(
                name: "SecurityGroup_MST",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AliasName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OwnerInternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin1InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin2InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin3InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityGroup_MST", x => x.InternalID);
                });

            migrationBuilder.CreateTable(
                name: "SecurityGroup_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AliasName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OwnerInternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin1InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin2InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin3InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityGroup_TRN", x => new { x.RequestID, x.Number });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAddress_MST");

            migrationBuilder.DropTable(
                name: "EmailAddress_TRN");

            migrationBuilder.DropTable(
                name: "Request_LST");

            migrationBuilder.DropTable(
                name: "SecurityGroup_MST");

            migrationBuilder.DropTable(
                name: "SecurityGroup_TRN");
        }
    }
}
