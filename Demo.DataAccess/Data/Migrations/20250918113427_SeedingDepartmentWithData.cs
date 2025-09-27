using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDepartmentWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "IsDeleted", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 50, "MKT", 0, new DateOnly(2022, 9, 18), "Focuses on advertising, branding, and outreach", false, 0, "Marketing" },
                    { 60, "SLS", 0, new DateOnly(2023, 9, 18), "Responsible for sales operations and client relationships", false, 0, "Sales" },
                    { 70, "RND", 0, new DateOnly(2019, 9, 18), "Innovates and develops new products and services", false, 0, "R&D" },
                    { 80, "SUP", 0, new DateOnly(2024, 9, 18), "Provides technical and customer support", false, 0, "Support" },
                    { 90, "FIN", 0, new DateOnly(2021, 9, 18), "Handles company finances, payroll, and budgets", false, 0, "Finance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 90);
        }
    }
}
