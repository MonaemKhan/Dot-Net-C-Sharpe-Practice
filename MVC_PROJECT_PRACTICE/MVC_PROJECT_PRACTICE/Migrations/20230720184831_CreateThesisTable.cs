using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_PROJECT_PRACTICE.Migrations
{
    public partial class CreateThesisTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThesisDetails",
                columns: table => new
                {
                    ThesisID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThesisName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThesisTeacherId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ThesisStudentId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentRegNo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CreatedAt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisDetails", x => x.ThesisID);
                    table.ForeignKey(
                        name: "FK_ThesisDetails_StudentDetails_StudentRegNo",
                        column: x => x.StudentRegNo,
                        principalTable: "StudentDetails",
                        principalColumn: "StudentRegNo");
                    table.ForeignKey(
                        name: "FK_ThesisDetails_TeacherDetails_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeacherDetails",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThesisDetails_StudentRegNo",
                table: "ThesisDetails",
                column: "StudentRegNo");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisDetails_TeacherId",
                table: "ThesisDetails",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesisDetails");
        }
    }
}
