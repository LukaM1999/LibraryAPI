using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCL.Migrations
{
    public partial class SoftDeleteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a7380991-3741-4031-8ebf-1aaebd4df374");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "300df285-01a8-4f6b-8529-44a826529b15");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0a5dd486-8ac2-4a24-9cab-3fac9efdf054");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "a0723a84-1bdf-43fa-9737-b617eda8779a", new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9652), new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9653), "74dadc65-91ec-48c6-8a22-15853d195fda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "40dd5a97-3a21-4375-9cf7-ff3809cdbefe", new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9659), new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9659), "53c52020-c316-4779-8f1e-6faf908c35ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "10276fa4-c0ab-499d-8d57-e00bd9849538", new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9672), new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9673), "fa5211c1-15fa-436d-8e9a-b57cbe1eeda2" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1506), new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1506) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1508), new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1508) });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Created", "Deleted", "FirstName", "LastName", "ModifiedDate" },
                values: new object[] { 3, new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1509), false, "Nick", "Chapsas", new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1509) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1598), new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1598) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1599), new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1600), new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Created", "ModifiedDate" },
                values: new object[] { 3, new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1600), new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1601) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a23d366f-a04e-4110-b07c-c977bfa47a19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "eb9cd6ea-bf7e-4b13-844a-63a061e6bdd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "846fd443-c61e-4ab4-999a-fe0d17c59986");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "b6e7ecc8-c077-46dd-b3fc-bcd391243bb2", new DateTime(2023, 2, 22, 8, 33, 19, 231, DateTimeKind.Utc).AddTicks(6435), new DateTime(2023, 2, 22, 8, 33, 19, 231, DateTimeKind.Utc).AddTicks(6435), "b1cd6553-9494-457d-984f-cbd1b87d6bbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "af58acec-8c0e-446d-9485-4370a31ad79f", new DateTime(2023, 2, 22, 8, 33, 19, 231, DateTimeKind.Utc).AddTicks(6444), new DateTime(2023, 2, 22, 8, 33, 19, 231, DateTimeKind.Utc).AddTicks(6444), "2ae2a26e-f0ef-4085-bfe9-5f1fe6035e9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "f6208e0c-9d1a-4797-b429-43e225ff9220", new DateTime(2023, 2, 22, 8, 33, 19, 231, DateTimeKind.Utc).AddTicks(6456), new DateTime(2023, 2, 22, 8, 33, 19, 231, DateTimeKind.Utc).AddTicks(6456), "5c8fc7db-a41a-403a-8551-3df1fd8809fb" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1420), new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1422), new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1422) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1522), new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1523), new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1523) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1524), new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1524) });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Created", "ModifiedDate" },
                values: new object[] { 2, new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1525), new DateTime(2023, 2, 22, 8, 33, 19, 234, DateTimeKind.Utc).AddTicks(1525) });
        }
    }
}
