using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class OnetoOneRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                schema: "Sales",
                table: "Departments",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                schema: "Sales",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                schema: "Sales",
                table: "Departments");
        }
    }
}
