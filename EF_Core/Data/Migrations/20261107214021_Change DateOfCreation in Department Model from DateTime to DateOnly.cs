using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateOfCreationinDepartmentModelfromDateTimetoDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfCreation",
                schema: "Sales",
                table: "Departments",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldComputedColumnSql: "GETDATE()");

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfCreation",
                value: new DateOnly(2023, 11, 5));

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfCreation",
                value: new DateOnly(2025, 6, 5));

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfCreation",
                value: new DateOnly(2024, 8, 20));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfCreation",
                schema: "Sales",
                table: "Departments",
                type: "date",
                nullable: true,
                computedColumnSql: "GETDATE()",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
