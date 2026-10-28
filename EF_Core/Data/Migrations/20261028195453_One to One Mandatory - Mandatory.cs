using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class OnetoOneMandatoryMandatory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpAddress_City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Street",
                table: "Employees");
        }
    }
}
