using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account_MST",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PresentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvincialAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Department_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manager_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_MST", x => new { x.InternalID, x.AccountID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account_MST");
        }
    }
}
