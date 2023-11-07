using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_AUTH_Parctice.Migrations
{
    /// <inheritdoc />
    public partial class CreateStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "CreatedBy", "Email", "Name", "Phone", "University" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 11, 5, 6, 4, 31, 255, DateTimeKind.Unspecified).AddTicks(4388), new TimeSpan(0, 0, 0, 0, 0)), "Khanmonaem07@gmail.com", "Monaem", "01303271848", "Rangamati Science and Technology University" },
                    { 2, new DateTimeOffset(new DateTime(2023, 11, 5, 6, 4, 31, 255, DateTimeKind.Unspecified).AddTicks(4399), new TimeSpan(0, 0, 0, 0, 0)), "Khanmonaem077@gmail.com", "Monaem Khan", "01832233593", "Rangamati Science and Technology University" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Id",
                table: "Student",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
