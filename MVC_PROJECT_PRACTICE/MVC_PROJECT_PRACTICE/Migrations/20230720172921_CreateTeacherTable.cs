using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_PROJECT_PRACTICE.Migrations
{
    public partial class CreateTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherDetails",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherFaculty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherDepartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherJoinDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDetails", x => x.TeacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherDetails");
        }
    }
}
