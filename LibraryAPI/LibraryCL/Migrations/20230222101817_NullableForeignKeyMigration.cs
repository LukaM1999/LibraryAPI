using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCL.Migrations
{
    public partial class NullableForeignKeyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "83b6b813-617a-4774-9c3d-543fa3d6f5bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4ecdde7a-5d88-471a-8e3d-cd5a9a369a2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "01582948-d107-409c-bee0-0f4708858346");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "316c0634-f976-45f2-83a0-c681b14dbca3", new DateTime(2023, 2, 22, 9, 44, 26, 292, DateTimeKind.Utc).AddTicks(2303), new DateTime(2023, 2, 22, 9, 44, 26, 292, DateTimeKind.Utc).AddTicks(2303), "7a9bff02-9b35-4056-93d6-9d2d26fd1e5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "a72f71d5-ed88-4f3f-8a13-7bc01e09d740", new DateTime(2023, 2, 22, 9, 44, 26, 292, DateTimeKind.Utc).AddTicks(2310), new DateTime(2023, 2, 22, 9, 44, 26, 292, DateTimeKind.Utc).AddTicks(2310), "ca6876d3-1559-40e1-a0e3-556891cd7190" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "805fadaf-5d8c-4abf-bb17-a3828aef8c26", new DateTime(2023, 2, 22, 9, 44, 26, 292, DateTimeKind.Utc).AddTicks(2316), new DateTime(2023, 2, 22, 9, 44, 26, 292, DateTimeKind.Utc).AddTicks(2316), "6c9b990b-796f-44d4-b1c9-921763988ae8" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(955), new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(958), new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(959), new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1030), new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1031), new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1032), new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1033), new DateTime(2023, 2, 22, 9, 44, 26, 294, DateTimeKind.Utc).AddTicks(1033) });
        }
    }
}
