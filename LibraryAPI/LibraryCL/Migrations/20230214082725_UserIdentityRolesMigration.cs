using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCL.Migrations
{
    public partial class UserIdentityRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "021fafd0-d5e1-4181-9431-72b4b19f938f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "478ba257-465b-457b-9eca-77e038ea5ce7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e5a240ff-1f81-483d-a1cc-f52c8ce60454");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "2c6f174e-3b0e-446f-86af-483d56fd7210" },
                    { "3b5e174e-3b0e-446f-86af-483d56fd7210", "3b7g174e-3b0e-446f-86af-483d56fd7210" },
                    { "4a5e174e-3b0e-446f-86af-483d56fd7210", "4a8h174e-3b0e-446f-86af-483d56fd7210" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "b54dc860-b817-4829-bcc0-85e47f2ab7fc", new DateTime(2023, 2, 14, 8, 27, 25, 289, DateTimeKind.Utc).AddTicks(9774), new DateTime(2023, 2, 14, 8, 27, 25, 289, DateTimeKind.Utc).AddTicks(9775), "0fe11c01-56c2-4fd2-a7d9-66e175045fd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "6f580666-d8cc-469a-ac86-622dff2dc2a4", new DateTime(2023, 2, 14, 8, 27, 25, 289, DateTimeKind.Utc).AddTicks(9780), new DateTime(2023, 2, 14, 8, 27, 25, 289, DateTimeKind.Utc).AddTicks(9781), "faf786e8-01f8-47ff-bc5d-49c0ea1aa145" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "3ad55cc3-6c60-43ea-b72c-103489c3db10", new DateTime(2023, 2, 14, 8, 27, 25, 289, DateTimeKind.Utc).AddTicks(9786), new DateTime(2023, 2, 14, 8, 27, 25, 289, DateTimeKind.Utc).AddTicks(9786), "7c8c6866-e867-4496-9b02-84a547de4b7a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "2c6f174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3b5e174e-3b0e-446f-86af-483d56fd7210", "3b7g174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4a5e174e-3b0e-446f-86af-483d56fd7210", "4a8h174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "db53191a-44fd-42ac-8e6c-1a1fff8ffe75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "412c692a-7d55-4486-82e4-a9da9574e497");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "11ae9c79-19c8-4b5a-b060-0515feb59b13");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6f174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "a2e400e7-225b-4994-b56f-50bb76be07c2", new DateTime(2023, 2, 14, 8, 18, 19, 617, DateTimeKind.Utc).AddTicks(6125), new DateTime(2023, 2, 14, 8, 18, 19, 617, DateTimeKind.Utc).AddTicks(6125), "050b64c5-0c06-4bcb-9211-708852759c2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b7g174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "5d60a8f1-f02e-402e-af40-f347208439aa", new DateTime(2023, 2, 14, 8, 18, 19, 617, DateTimeKind.Utc).AddTicks(6132), new DateTime(2023, 2, 14, 8, 18, 19, 617, DateTimeKind.Utc).AddTicks(6132), "021160bb-f411-4266-b3d8-2b4b4b1c6a9a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a8h174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "SecurityStamp" },
                values: new object[] { "04e14956-0872-4e0d-b759-44e706ee298f", new DateTime(2023, 2, 14, 8, 18, 19, 617, DateTimeKind.Utc).AddTicks(6137), new DateTime(2023, 2, 14, 8, 18, 19, 617, DateTimeKind.Utc).AddTicks(6138), "781cee00-3c47-478f-9229-1afa1c6312ec" });
        }
    }
}
