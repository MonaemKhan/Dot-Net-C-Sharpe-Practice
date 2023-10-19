using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Emp");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Emp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Courencies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Emp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Emp",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "Emp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Emp",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Emp",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Emp",
                table: "Country",
                columns: new[] { "Id", "CountryName", "Courencies", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Status" },
                values: new object[,]
                {
                    { 1, "BanglaDesh", "Taka", new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 240, DateTimeKind.Unspecified).AddTicks(8192), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, 1 },
                    { 2, "India", "Rupi", new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 240, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Emp",
                table: "State",
                columns: new[] { "Id", "CountryId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "StateName", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(7986), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Dhaka", 1 },
                    { 2, 2, new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(7999), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Rajshahi", 1 }
                });

            migrationBuilder.InsertData(
                schema: "Emp",
                table: "Employee",
                columns: new[] { "Id", "Address", "Age", "CountryId", "Created", "CreatedBy", "FirstName", "LastModified", "LastModifiedBy", "LastName", "PhoneNumber", "StateId", "Status" },
                values: new object[,]
                {
                    { 1, "Dhaka", 26, 1, new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(3004), new TimeSpan(0, 6, 0, 0, 0)), "1", "M.A. Monaem", null, null, "Khan", "01303271849", 1, 1 },
                    { 2, "Dhaka", 26, 2, new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(3019), new TimeSpan(0, 6, 0, 0, 0)), "1", "M.A.", null, null, "Khan", "013", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryName",
                schema: "Emp",
                table: "Country",
                column: "CountryName");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                schema: "Emp",
                table: "Employee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FirstName",
                schema: "Emp",
                table: "Employee",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StateId",
                schema: "Emp",
                table: "Employee",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                schema: "Emp",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_State_StateName",
                schema: "Emp",
                table: "State",
                column: "StateName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee",
                schema: "Emp");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Emp");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Emp");
        }
    }
}
