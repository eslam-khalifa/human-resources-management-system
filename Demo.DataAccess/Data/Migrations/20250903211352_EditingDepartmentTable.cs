using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditingDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "LastModifiedOn",
                table: "Departments",
                type: "date",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComputedColumnSql: "getdate()");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatedOn",
                table: "Departments",
                type: "date",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                computedColumnSql: "getdate()",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");
        }
    }
}
