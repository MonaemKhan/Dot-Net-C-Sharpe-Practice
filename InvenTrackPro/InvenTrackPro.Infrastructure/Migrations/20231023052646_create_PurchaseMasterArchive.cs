using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTrackPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_PurchaseMasterArchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseMasterArchive",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    supplierCode = table.Column<int>(type: "int", nullable: false),
                    PurchaseCode = table.Column<int>(type: "int", nullable: false),
                    PurchaseType = table.Column<int>(type: "int", nullable: false),
                    Warranty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Attn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BRID = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    LCNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LCDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TransactionCodePreTurnNo = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    ChangeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ChangeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EdEvents = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseMasterArchive", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "PurchaseMasterArchive",
                columns: new[] { "Id", "Attn", "BRID", "ChangeDate", "ChangeUser", "CreatedBy", "CreatedDate", "EdEvents", "IsActive", "IsDelete", "LCDate", "LCNo", "ModifiedBy", "ModifiedDate", "PONo", "PurchaseCode", "PurchaseType", "Remarks", "TrackId", "TransactionCode", "TransactionCodePreTurnNo", "TransactionDate", "TransactionId", "TransactionType", "UserId", "Warranty", "YearId", "supplierCode" },
                values: new object[] { 1L, "ABC", 1, new DateTimeOffset(new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), "CNG USER 01", 1L, new DateTimeOffset(new DateTime(2023, 10, 23, 5, 26, 46, 38, DateTimeKind.Unspecified).AddTicks(4135), new TimeSpan(0, 0, 0, 0, 0)), "EVT 01", true, false, new DateTimeOffset(new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), "LC 01", null, null, "PO 01", 1, 1, "Very Good", 1, "MO121", 1, new DateTimeOffset(new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), 1, 1, "USer 01", "2 years", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseMasterArchive");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08dc988a-f32e-4118-88e4-20d7afbb031f", "AQAAAAIAAYagAAAAEJICdb9NlI4xVIwxpduNbWYMFYHE6X57EQGd6RvAJuWSp684zXX0/VdICk1Zyp362A==", "1001d9d9-f6c3-4452-bf83-b08ab2e12dc9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3392fc9a-1a1c-4737-92f4-2cda0588811d", "AQAAAAIAAYagAAAAEBGIfYEb6q2KlW1QgYjgV8gnaot+QXgLUsQ/Rq1zcBE51Tsk6dPu6peL2zvyhQwMCg==", "c68196f2-1642-4280-be4b-3435d878a9f9" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 22, 5, 32, 57, 987, DateTimeKind.Unspecified).AddTicks(6743), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
