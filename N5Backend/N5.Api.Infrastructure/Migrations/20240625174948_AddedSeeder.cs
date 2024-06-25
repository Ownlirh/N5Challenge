using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N5.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "UI/UX" },
                    { 2, "Programmer" },
                    { 3, "Designer" },
                    { 4, "Team Lead" }
                });

            migrationBuilder.InsertData(
                table: "EmployerPermissions",
                columns: new[] { "Id", "CreatedAt", "Name", "PermissionId", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4794), "Jhon", 1, "Doe" },
                    { 2, new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4802), "Jane", 2, "Doe" },
                    { 3, new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4804), "Seven", 3, "Doe" },
                    { 4, new DateTime(2024, 6, 25, 17, 49, 48, 20, DateTimeKind.Utc).AddTicks(4805), "Clop", 4, "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployerPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployerPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployerPermissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployerPermissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PermissionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PermissionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PermissionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PermissionTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
