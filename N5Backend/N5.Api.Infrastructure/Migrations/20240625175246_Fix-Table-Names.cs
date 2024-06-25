using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N5.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerPermissions");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionTypes_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "PermissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Name", "PermissionId", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 25, 17, 52, 46, 273, DateTimeKind.Utc).AddTicks(9914), "Jhon", 1, "Doe" },
                    { 2, new DateTime(2024, 6, 25, 17, 52, 46, 273, DateTimeKind.Utc).AddTicks(9916), "Jane", 2, "Doe" },
                    { 3, new DateTime(2024, 6, 25, 17, 52, 46, 273, DateTimeKind.Utc).AddTicks(9917), "Seven", 3, "Doe" },
                    { 4, new DateTime(2024, 6, 25, 17, 52, 46, 273, DateTimeKind.Utc).AddTicks(9919), "Clop", 4, "Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionId",
                table: "Permissions",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.CreateTable(
                name: "EmployerPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerPermissions_PermissionTypes_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "PermissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_EmployerPermissions_PermissionId",
                table: "EmployerPermissions",
                column: "PermissionId");
        }
    }
}
