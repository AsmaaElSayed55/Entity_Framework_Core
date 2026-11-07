using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeManagerIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_ManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                schema: "Sales",
                table: "Departments",
                type: "varchar(20)",
                nullable: true,
                defaultValue: "HR",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldDefaultValue: "HR");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                schema: "Sales",
                table: "Departments",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_ManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                schema: "Sales",
                table: "Departments",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "HR",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true,
                oldDefaultValue: "HR");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                schema: "Sales",
                table: "Departments",
                column: "ManagerId",
                unique: true);
        }
    }
}
