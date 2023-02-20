using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCL.Migrations
{
    public partial class UserAuthorizationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "9e27cebe-a3b9-4411-b117-01d162926b62", new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4003), new DateTime(2023, 2, 20, 12, 44, 57, 201, DateTimeKind.Utc).AddTicks(4004), "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "d0b9b9af-f758-4e0f-9e68-8eff052f2189" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c91086ea-71d8-4766-9de1-faa00876ce9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a4ff8942-6011-4c3c-afce-73e0763edd2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f5e825f2-08c7-4050-87f0-e6569acde71e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "13df036e-d05e-4b96-a126-4cbd0c0fe6be", new DateTime(2023, 2, 20, 12, 35, 12, 863, DateTimeKind.Utc).AddTicks(1738), new DateTime(2023, 2, 20, 12, 35, 12, 863, DateTimeKind.Utc).AddTicks(1738), null, null, "65fe63fd-5314-48ed-9eb2-b0f5e1d97667" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "2641896b-7576-4a24-8698-ab5458e0690d", new DateTime(2023, 2, 20, 12, 35, 12, 863, DateTimeKind.Utc).AddTicks(1748), new DateTime(2023, 2, 20, 12, 35, 12, 863, DateTimeKind.Utc).AddTicks(1748), "25cd14a2-16bd-4b97-967c-2f651d8a9185" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "20456142-da48-4f05-b9fe-33af3b6ef95b", new DateTime(2023, 2, 20, 12, 35, 12, 863, DateTimeKind.Utc).AddTicks(1762), new DateTime(2023, 2, 20, 12, 35, 12, 863, DateTimeKind.Utc).AddTicks(1763), "24883215-0f60-40d6-a3dd-06a579cf3b5a" });
        }
    }
}
