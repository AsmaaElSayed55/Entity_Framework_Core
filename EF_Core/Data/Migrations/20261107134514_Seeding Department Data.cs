using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDepartmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Departments",
                columns: new[] { "Id", "ManagerId", "DepartmentName" },
                values: new object[,]
                {
                    { 5, null, "PR" },
                    { 6, null, "PM" },
                    { 7, null, "Digital" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
