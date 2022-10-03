using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarBank.Server.Migrations
{
    public partial class SeedingDatasToMyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Payrool" },
                    { 4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "sara@pragimtech.com", "Sara", 1, "Longway", "images/sara.png" },
                    { 2, new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "david@infotech.com", "David", 0, "Samuel", "images/david.png" },
                    { 3, new DateTime(1992, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "slyverster@infotech.com", "Slyvester", 0, "Muoghalu", "images/slyvester.png" },
                    { 4, new DateTime(1992, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "joy@infotech.com", "Joy", 0, "Silver", "images/slyvester.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4);
        }
    }
}
