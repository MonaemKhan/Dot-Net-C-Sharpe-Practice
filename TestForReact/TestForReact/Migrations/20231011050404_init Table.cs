using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestForReact.Migrations
{
    /// <inheritdoc />
    public partial class initTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTable_CountryTable_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMployeeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMployeeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMployeeTable_CityTable_CityId",
                        column: x => x.CityId,
                        principalTable: "CityTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMployeeTable_CountryTable_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityTable_CountryId",
                table: "CityTable",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EMployeeTable_CityId",
                table: "EMployeeTable",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EMployeeTable_CountryId",
                table: "EMployeeTable",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMployeeTable");

            migrationBuilder.DropTable(
                name: "CityTable");

            migrationBuilder.DropTable(
                name: "CountryTable");
        }
    }
}
