using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JDRSportsAcademy.Migrations
{
    public partial class Coach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CoachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportID = table.Column<int>(type: "int", nullable: false),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CoachID);
                    table.ForeignKey(
                        name: "FK_Coach_Sport_SportID",
                        column: x => x.SportID,
                        principalTable: "Sport",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coach_SportID",
                table: "Coach",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coach");
        }
    }
}
