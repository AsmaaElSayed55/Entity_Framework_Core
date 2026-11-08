using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class FluentAPIs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Departments",
                newSchema: "Sales");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "EmployeeName");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                schema: "Sales",
                table: "Departments",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "HR");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfCreation",
                schema: "Sales",
                table: "Departments",
                type: "date",
                nullable: true,
                computedColumnSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                schema: "Sales",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
