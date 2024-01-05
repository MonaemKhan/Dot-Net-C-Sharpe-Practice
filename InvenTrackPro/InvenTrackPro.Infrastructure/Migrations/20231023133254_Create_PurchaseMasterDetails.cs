using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTrackPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_PurchaseMasterDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseMasterDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    QunIt = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RunIt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MSLNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BRID = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseMasterDetails", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad175f1-0a57-4685-9d3b-b2917ba3552b", "AQAAAAIAAYagAAAAEOKAiS+kaNy0qM0jVb2f4DHTIITc9JCNe61ctoTj4WuPt3Ny+ntp3NYe8xQHhHq6XA==", "65f750a1-1ef3-4d58-91ce-ac97ed3484ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb462d4c-2795-42bf-befd-f9dadf64b3fa", "AQAAAAIAAYagAAAAEMSBujHNeLsZyAJZKjeX5U5hq7su6H5yXmeg37CEVvUFNhTO7lTUXHkRUyFGQ6qkew==", "0588ee93-6d94-4ffe-a0b1-2922e29839cb" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 13, 32, 53, 709, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 13, 32, 53, 725, DateTimeKind.Unspecified).AddTicks(6923), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "PurchaseMasterDetails",
                columns: new[] { "Id", "BRID", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "ItemId", "MSLNo", "ModifiedBy", "ModifiedDate", "Quantity", "QunIt", "Rate", "RunIt", "TransactionId", "TransactionType", "YearId" },
                values: new object[] { 1L, 1, 1L, new DateTimeOffset(new DateTime(2023, 10, 23, 13, 32, 53, 729, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, "abc123", null, null, 10, "xyz", 10.1, "abc", 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseMasterDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e437db5-bf0d-446d-8214-10be281b5384", "AQAAAAIAAYagAAAAEEFKA3QrBfc7kQjUuIoxRczTIGP0hxh+o2bc/wVB2XB3w+vEQi4GOgz6LSIJNGC6ow==", "407e440f-96a2-46d0-8611-e0e2fcd513f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93827a59-56c0-40cc-9335-d5cb8ab56c1e", "AQAAAAIAAYagAAAAEOCHxZ2mBWPvlzY46InxaEasGQwV+HKN02OIF/wqGBbr+4f7Dpkt1H6Zhpz0/XaMpg==", "22d043b5-b79d-4423-993b-7e10d896dc82" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 5, 26, 46, 33, DateTimeKind.Unspecified).AddTicks(424), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 5, 26, 46, 38, DateTimeKind.Unspecified).AddTicks(4135), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
