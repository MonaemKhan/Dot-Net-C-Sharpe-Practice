using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTrackPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempItemListReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Parent = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    TopParent = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    LR = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Depth = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 20, nullable: true, defaultValueSql: "(getdate())"),
                    QUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PartsNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ItemOrder = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    SalesUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OpenQty = table.Column<float>(type: "real", maxLength: 20, nullable: true),
                    PurRate = table.Column<float>(type: "real", maxLength: 20, nullable: true),
                    SaleRate = table.Column<float>(type: "real", maxLength: 20, nullable: true),
                    ReOrderQty = table.Column<float>(type: "real", maxLength: 20, nullable: true),
                    CompyearId = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    CompId = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempItemListReport", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24a9f9dd-4c76-4bf8-bbb3-032e3843c87e", "AQAAAAIAAYagAAAAEM6HKa/hX4DIRLdDAi5ao1EOBURQPawm9Svf9KWJDi0U/klcjf4nwdgp3IfuUQBsuA==", "b1fb03da-37c7-4c45-abda-660565fe710b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ab247dc-714d-44d1-b161-b569ccc1fbc4", "AQAAAAIAAYagAAAAEMWODQ/rJcDP6cZDNCxPlyaYs/01up4HhR14n7eWckDm1S2SlFmBo4fXFa/oORR0Mg==", "90c083f8-dc9b-4355-bc56-5d912895a4a4" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 27, 16, 14, 45, 116, DateTimeKind.Unspecified).AddTicks(9755), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "TempItemListReport",
                columns: new[] { "Id", "CompId", "CompyearId", "CreateDate", "CreatedBy", "CreatedDate", "Depth", "IsActive", "IsDelete", "ItemCode", "ItemId", "ItemName", "ItemOrder", "LR", "ModifiedBy", "ModifiedDate", "OpenQty", "Parent", "PartsNo", "PurRate", "QUnit", "RUnit", "ReOrderQty", "SaleRate", "SalesUnit", "TopParent", "UserId" },
                values: new object[] { 1L, 1, 1, new DateTimeOffset(new DateTime(2023, 10, 27, 22, 14, 45, 122, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 6, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(2023, 10, 27, 16, 14, 45, 122, DateTimeKind.Unspecified).AddTicks(9830), new TimeSpan(0, 0, 0, 0, 0)), 12, true, false, "", 1234, "12", 123, "1", null, null, 3f, 1234, "1234", 1234f, "", "1234", 1234f, 1234f, "1234", 1234, "1234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempItemListReport");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43aca55e-fccf-4bb3-9a83-949427a69359", "AQAAAAIAAYagAAAAECAkTUfKUWdJh5fmcVzZiR+kz4bZ7+fpjF9vww3rQlm6t0wRQ/vKeLgpaTyQxxdsYA==", "e2c3a01a-a036-4b3f-853e-3acd7eaa7edf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73db8777-731f-4bf2-be7a-cb5f29152cb8", "AQAAAAIAAYagAAAAEPHxKIRqsRbuQgD2F9fRrQXUzTslxst4VLltD2TNdBCg0V4RSsDCHzCHxJvzrUQWTQ==", "cd37d246-25c7-4fbd-9925-78867759c247" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 10, 24, 16, 55, 56, 706, DateTimeKind.Unspecified).AddTicks(4238), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
