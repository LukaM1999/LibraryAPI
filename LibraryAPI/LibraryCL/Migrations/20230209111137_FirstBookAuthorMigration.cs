using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCL.Migrations
{
    public partial class FirstBookAuthorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Password" },
                values: new object[] { new DateTime(2023, 2, 9, 12, 11, 37, 640, DateTimeKind.Local).AddTicks(2170), new DateTime(2023, 2, 9, 12, 11, 37, 640, DateTimeKind.Local).AddTicks(2220), "SecurePass123!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Password" },
                values: new object[] { new DateTime(2023, 2, 9, 10, 35, 32, 77, DateTimeKind.Local).AddTicks(9164), new DateTime(2023, 2, 9, 10, 35, 32, 77, DateTimeKind.Local).AddTicks(9195), "123" });
        }
    }
}
