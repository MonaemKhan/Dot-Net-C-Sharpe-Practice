using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTrackPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_QuanIT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuanIT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QunITName = table.Column<string>(type: "nvarchar(30)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanIT", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e33b0eb-da44-47e2-8ce0-2ed0de93486d", "AQAAAAIAAYagAAAAECLxNOIQ3UTbQEThoH3cNgKlceNJkIryB+bG46UIYo1KSXHeaFNvHND1ONbjNSHfaw==", "1d96ad84-2cb2-466d-8e88-5909d9390801" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ff7eb4b-5f8e-4dd0-a30c-ccab5b7baa41", "AQAAAAIAAYagAAAAENWhosOeLuCcDukhJsYep2rFZgQ1PX6A/M71QT4bS5uBQDR6MSjGf5RV7/2nXox/sA==", "7f25ecd0-66a9-4128-a28e-99068584a8ba" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 16, 58, 19, 59, DateTimeKind.Unspecified).AddTicks(8241), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 16, 58, 19, 64, DateTimeKind.Unspecified).AddTicks(9484), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 16, 58, 19, 69, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterDetailsArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 16, 58, 19, 67, DateTimeKind.Unspecified).AddTicks(6204), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "QuanIT",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "ModifiedBy", "ModifiedDate", "QunITName" },
                values: new object[] { 1L, 1L, new DateTimeOffset(new DateTime(2023, 10, 24, 16, 58, 19, 70, DateTimeKind.Unspecified).AddTicks(8865), new TimeSpan(0, 0, 0, 0, 0)), true, false, null, null, "xyz" });

            migrationBuilder.UpdateData(
                table: "RepairService",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ReceiveDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 24, 16, 58, 19, 73, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 10, 24, 22, 58, 19, 73, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 6, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuanIT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6469e51e-3ffc-4a29-9fd2-13607646a7b8", "AQAAAAIAAYagAAAAEHUCxDH8dkz1X48/BF8fTBvXAaWbRcRtOBuhEGYeotl4BFNXPjNZCqI8PbjGulXpjw==", "c17ecb8a-a87f-4856-ab36-5f0043a260ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "949cf875-a2f9-435a-b654-4f4f2ecc12de", "AQAAAAIAAYagAAAAEG/HPPEJblbV0oMS5U5auY6NMCBrL2tEfDxAHKbI+8cEZhBsOh/Vuc783qaG8JrRkw==", "39800db5-1418-4727-84cf-04b7ac88dc05" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 598, DateTimeKind.Unspecified).AddTicks(8928), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 608, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 616, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterDetailsArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 612, DateTimeKind.Unspecified).AddTicks(6606), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RepairService",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ReceiveDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 620, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 10, 24, 17, 25, 52, 620, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
