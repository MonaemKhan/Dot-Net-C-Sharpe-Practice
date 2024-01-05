using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTrackPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_RepairService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairService",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairId = table.Column<int>(type: "int", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    VNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VType = table.Column<int>(type: "int", nullable: false),
                    ReceiveDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GSXNO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SRNO = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PartsAmount = table.Column<double>(type: "float", nullable: false),
                    ServiceAmount = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    DollerAmount = table.Column<double>(type: "float", nullable: false),
                    DollerFract = table.Column<double>(type: "float", nullable: false),
                    DollerExchangeRate = table.Column<double>(type: "float", nullable: false),
                    BRId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairService", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "RepairService",
                columns: new[] { "Id", "BRId", "CreatedBy", "CreatedDate", "DollerAmount", "DollerExchangeRate", "DollerFract", "GSXNO", "IsActive", "IsDelete", "ModifiedBy", "ModifiedDate", "Particulars", "PartsAmount", "PartyId", "ReceiveDate", "RepairId", "SRNO", "ServiceAmount", "TotalAmount", "UserName", "VNo", "VType", "YearId" },
                values: new object[] { 1L, 1, 1L, new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 620, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 0, 0, 0, 0)), 10.0, 100.0, 5.0, "abc", true, false, null, null, "abc", 10.300000000000001, 1, new DateTimeOffset(new DateTime(2023, 10, 24, 17, 25, 52, 620, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 6, 0, 0, 0)), 1, "abc", 1000.001, 1100.3009999999999, "Monaem", "xyz123", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairService");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2922fe7-e936-4783-92da-f380395b6d58", "AQAAAAIAAYagAAAAEEWu6Eq63TarnueJNHtzs17dr/peX+x2+Oj8G0BYawwmoEx+mMR/73wm+sX9EWqyHg==", "4a5696b7-81a0-46e3-8a51-36e623cad0c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebc4b5b5-3bf6-4696-9004-1025e5763fa4", "AQAAAAIAAYagAAAAEJhjoVmgV7zdmobfgFaKq+EvXwBM6571ZO25Xz8V3Z5bb3JA7VxvhYahLgGxM0pGfw==", "278cd1e8-c0ce-4ab7-8357-fe79571422fe" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 17, 40, 33, 785, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 17, 40, 33, 788, DateTimeKind.Unspecified).AddTicks(3397), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 17, 40, 33, 792, DateTimeKind.Unspecified).AddTicks(2148), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "PurchaseMasterDetailsArchive",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 23, 17, 40, 33, 790, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
