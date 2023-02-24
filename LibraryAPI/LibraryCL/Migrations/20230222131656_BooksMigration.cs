using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCL.Migrations
{
    public partial class BooksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Book",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Author",
                newName: "CreatedDate");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "69f51e46-85c4-415f-9073-105f8482f73f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ce41b309-d82c-4f18-b616-31552fae5c74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e9d039f7-881f-4097-b920-55636440baa3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "50f91784-049c-4a4c-8d63-871ae773bb81", new DateTime(2023, 2, 22, 13, 16, 56, 95, DateTimeKind.Utc).AddTicks(693), new DateTime(2023, 2, 22, 13, 16, 56, 95, DateTimeKind.Utc).AddTicks(693), "1c20b81b-c541-48c2-8adc-2b974bd91cbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "255e18e8-a52e-45cc-9367-897041b30822", new DateTime(2023, 2, 22, 13, 16, 56, 95, DateTimeKind.Utc).AddTicks(701), new DateTime(2023, 2, 22, 13, 16, 56, 95, DateTimeKind.Utc).AddTicks(701), "bbf9c8a0-910b-4899-8b77-98dd58df9271" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "e40a60d1-6107-4dbe-b359-4b6cefc97a1c", new DateTime(2023, 2, 22, 13, 16, 56, 95, DateTimeKind.Utc).AddTicks(758), new DateTime(2023, 2, 22, 13, 16, 56, 95, DateTimeKind.Utc).AddTicks(758), "6eff8dcd-7cd4-4a6e-874f-bfe816b671fa" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6078), new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6081), new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6081) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6082), new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6169), new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6169) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6170), new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6171), new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6171) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6171), new DateTime(2023, 2, 22, 13, 16, 56, 97, DateTimeKind.Utc).AddTicks(6172) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Book",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Author",
                newName: "Created");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ac04957d-133f-4c2a-b547-b7d7e4cf922e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6ba59a4b-9c2c-424a-bdf5-ef70480deae5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b6a01614-fb09-4249-94dd-603443fa1046");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "4e87d0e5-f459-4eb8-b43c-fdbe2fecb9e7", new DateTime(2023, 2, 22, 10, 18, 17, 328, DateTimeKind.Utc).AddTicks(6394), new DateTime(2023, 2, 22, 10, 18, 17, 328, DateTimeKind.Utc).AddTicks(6394), "980d0d93-a808-427d-b823-cbf341fc59a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "eeed4236-14b3-439d-baf3-6ab685104e45", new DateTime(2023, 2, 22, 10, 18, 17, 328, DateTimeKind.Utc).AddTicks(6401), new DateTime(2023, 2, 22, 10, 18, 17, 328, DateTimeKind.Utc).AddTicks(6401), "e9f1701a-dd6d-4514-9192-1c92f04b4c32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "ba41a7c1-6b7a-4b61-a895-baaf54f9c5d0", new DateTime(2023, 2, 22, 10, 18, 17, 328, DateTimeKind.Utc).AddTicks(6417), new DateTime(2023, 2, 22, 10, 18, 17, 328, DateTimeKind.Utc).AddTicks(6417), "1f147c84-920c-4eb0-949c-fef1ab433c26" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(935), new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(942), new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(942) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(943), new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1040), new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1041) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1042), new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1043), new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1044), new DateTime(2023, 2, 22, 10, 18, 17, 331, DateTimeKind.Utc).AddTicks(1045) });
        }
    }
}
