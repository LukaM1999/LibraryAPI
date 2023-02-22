using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCL.Migrations
{
    public partial class AuthorsBooksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9963b208-f598-4486-b40c-a3d541559e7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4a2f53e4-9f9f-4d54-88bb-95bfb6f661c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0486a6aa-257f-4878-bfa4-6ddb19c84b6d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "66c21b1e-2e77-4a66-8c67-d257434b9297", new DateTime(2023, 2, 21, 16, 36, 34, 912, DateTimeKind.Utc).AddTicks(9372), new DateTime(2023, 2, 21, 16, 36, 34, 912, DateTimeKind.Utc).AddTicks(9373), "fd7a0150-f235-4688-82a7-bf56e47b81dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "36112163-4822-4228-975f-3bea49139b6b", new DateTime(2023, 2, 21, 16, 36, 34, 912, DateTimeKind.Utc).AddTicks(9379), new DateTime(2023, 2, 21, 16, 36, 34, 912, DateTimeKind.Utc).AddTicks(9379), "0834f609-a3db-4e91-bd7c-817a643a8f07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "f8a84356-a5cc-41e0-8ef4-a34156eb755d", new DateTime(2023, 2, 21, 16, 36, 34, 912, DateTimeKind.Utc).AddTicks(9403), new DateTime(2023, 2, 21, 16, 36, 34, 912, DateTimeKind.Utc).AddTicks(9403), "61dd88b1-a0e8-4b91-9224-046ab8469341" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Created", "FirstName", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5215), "Tom", "Paice", new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5216) },
                    { 2, new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5216), "Bob", "Vance", new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5217) }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Created", "ModifiedDate", "Name" },
                values: new object[] { 1, 1, new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5252), new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5252), "Marvelous Tale of Time" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Created", "ModifiedDate", "Name" },
                values: new object[] { 2, 1, new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5253), new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5253), "Marvelous Tale of Space" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Created", "ModifiedDate", "Name" },
                values: new object[] { 3, 2, new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5254), new DateTime(2023, 2, 21, 16, 36, 34, 914, DateTimeKind.Utc).AddTicks(5254), "Refrigeration 101" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2ebfaca2-7671-4a7d-8c0c-0f0c6b7652bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "465ab36e-8e51-4392-9aca-75a6bae929f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c8f57b9f-41ea-4629-9c42-731f7c1cd0e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "9e27cebe-a3b9-4411-b117-01d162926b62", new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4003), new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4004), "d0b9b9af-f758-4e0f-9e68-8eff052f2189" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "053064da-5c6d-4d0b-b5f9-96d3819fc2f0", new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4012), new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4012), "e492860e-b08e-443d-93e3-5f113632c42b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "0cff6d48-93cd-4458-8ff3-b12749d4f8ae", new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4050), new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4050), "0e24c4c3-94cf-4a6b-8785-4c5dfdd39b38" });
        }
    }
}
