using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_PROJECT_PRACTICE.Migrations
{
    public partial class CreateStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentRegNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentVillage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentDivision = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentFaculty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentDepartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentCredite = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.StudentRegNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetails");
        }
    }
}
