using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestDapartmentIdIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "10, 10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "10, 10")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Departments",
                columns: new[] { "Id", "ManagerId", "DepartmentName" },
                values: new object[,]
                {
                    { -2, null, "IT" },
                    { -1, null, "HR" }
                });
        }
    }
}
