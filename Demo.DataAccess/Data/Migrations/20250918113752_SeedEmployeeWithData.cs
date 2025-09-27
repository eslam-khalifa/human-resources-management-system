using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Age", "CreatedBy", "DepartmentId", "Email", "EmployeeType", "Gender", "HiringDate", "IsActive", "IsDeleted", "LastModifiedBy", "Name", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1004, "101-Cairo-Maadi-Egypt", 28, 0, 10, "alice.johnson@example.com", "FullTime", "Female", new DateTime(2023, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(116), true, false, 0, "Alice Johnson", "01012345678", 12000m },
                    { 1005, "202-Giza-Dokki-Egypt", 32, 0, 20, "omar.khaled@example.com", "PartTime", "Male", new DateTime(2022, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(155), true, false, 0, "Omar Khaled", "01098765432", 15000m },
                    { 1006, "303-Alexandria-SidiBishr-Egypt", 26, 0, 40, "mona.adel@example.com", "Intern", "Female", new DateTime(2024, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(162), false, false, 0, "Mona Adel", "01122334455", 10000m },
                    { 1007, "404-Cairo-NasrCity-Egypt", 40, 0, 50, "ahmed.samir@example.com", "FullTime", "Male", new DateTime(2015, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(167), true, false, 0, "Ahmed Samir", "01234567890", 20000m },
                    { 1008, "505-Cairo-Heliopolis-Egypt", 24, 0, 60, "sara.nabil@example.com", "Contract", "Female", new DateTime(2025, 1, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(173), true, false, 0, "Sara Nabil", "01566778899", 9000m },
                    { 1009, "606-Giza-Haram-Egypt", 35, 0, 70, "youssef.hany@example.com", "FullTime", "Male", new DateTime(2020, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(180), true, false, 0, "Youssef Hany", "01055667788", 17000m },
                    { 1010, "707-Cairo-Zamalek-Egypt", 29, 0, 80, "laila.hassan@example.com", "PartTime", "Female", new DateTime(2021, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(186), false, false, 0, "Laila Hassan", "01299887766", 11000m },
                    { 1011, "808-Cairo-Downtown-Egypt", 45, 0, 90, "khaled.mostafa@example.com", "FullTime", "Male", new DateTime(2010, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(191), true, false, 0, "Khaled Mostafa", "01044556677", 25000m },
                    { 1012, "909-Alexandria-Montaza-Egypt", 22, 0, 10, "nour.ahmed@example.com", "Intern", "Female", new DateTime(2025, 3, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(196), true, false, 0, "Nour Ahmed", "01533445566", 8000m },
                    { 1013, "1001-Cairo-Mokattam-Egypt", 38, 0, 20, "hussein.ali@example.com", "Contract", "Male", new DateTime(2018, 9, 18, 14, 37, 50, 885, DateTimeKind.Local).AddTicks(201), true, false, 0, "Hussein Ali", "01155667788", 18000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1013);
        }
    }
}
