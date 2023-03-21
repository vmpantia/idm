using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDM.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityGroup_MST",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AliasName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
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
                    Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
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
                    table.PrimaryKey("PK_SecurityGroup_TRN", x => new { x.RequestID, x.Number, x.InternalID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityGroup_MST");

            migrationBuilder.DropTable(
                name: "SecurityGroup_TRN");
        }
    }
}
