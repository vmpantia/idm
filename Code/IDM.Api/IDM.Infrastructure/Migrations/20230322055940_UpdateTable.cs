using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "SecurityGroup_TRN",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "SecurityGroup_MST",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "SecurityGroup_TRN",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "SecurityGroup_MST",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
