using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageNameColumnToEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateOnly(2022, 9, 21));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateOnly(2023, 9, 21));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedOn",
                value: new DateOnly(2024, 9, 21));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedOn",
                value: new DateOnly(2021, 9, 21));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2023, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8464), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2022, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8531), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2024, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8544), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2015, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8551), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2025, 1, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8560), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2020, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8569), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2021, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8581), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1011,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2010, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8588), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2025, 3, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8593), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1013,
                columns: new[] { "HiringDate", "ImageName" },
                values: new object[] { new DateTime(2018, 9, 21, 23, 13, 34, 109, DateTimeKind.Local).AddTicks(8600), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateOnly(2022, 9, 18));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateOnly(2023, 9, 18));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedOn",
                value: new DateOnly(2024, 9, 18));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedOn",
                value: new DateOnly(2021, 9, 18));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1004,
                column: "HiringDate",
                value: new DateTime(2023, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1005,
                column: "HiringDate",
                value: new DateTime(2022, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1006,
                column: "HiringDate",
                value: new DateTime(2024, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1007,
                column: "HiringDate",
                value: new DateTime(2015, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1008,
                column: "HiringDate",
                value: new DateTime(2025, 1, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1009,
                column: "HiringDate",
                value: new DateTime(2020, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1010,
                column: "HiringDate",
                value: new DateTime(2021, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1011,
                column: "HiringDate",
                value: new DateTime(2010, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1012,
                column: "HiringDate",
                value: new DateTime(2025, 3, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1013,
                column: "HiringDate",
                value: new DateTime(2018, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(201));
        }
    }
}
