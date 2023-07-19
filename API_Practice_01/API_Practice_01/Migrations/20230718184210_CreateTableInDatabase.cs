using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Practice_01.Migrations
{
    public partial class CreateTableInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentRegNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.StudentRegNo);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDetails",
                columns: table => new
                {
                    TecherRegNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TecherName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TeacherEmail = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TeacherPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDetails", x => x.TecherRegNo);
                });

            migrationBuilder.CreateTable(
                name: "ThesisDetails",
                columns: table => new
                {
                    ThesisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Teacher_RegNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TeacherTecherRegNo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Student_RegNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentRegNo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisDetails", x => x.ThesisId);
                    table.ForeignKey(
                        name: "FK_ThesisDetails_StudentDetails_StudentRegNo",
                        column: x => x.StudentRegNo,
                        principalTable: "StudentDetails",
                        principalColumn: "StudentRegNo");
                    table.ForeignKey(
                        name: "FK_ThesisDetails_TeacherDetails_TeacherTecherRegNo",
                        column: x => x.TeacherTecherRegNo,
                        principalTable: "TeacherDetails",
                        principalColumn: "TecherRegNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThesisDetails_StudentRegNo",
                table: "ThesisDetails",
                column: "StudentRegNo");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisDetails_TeacherTecherRegNo",
                table: "ThesisDetails",
                column: "TeacherTecherRegNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesisDetails");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "TeacherDetails");
        }
    }
}
