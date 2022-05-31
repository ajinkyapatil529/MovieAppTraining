using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class showdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieShowModels",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieShowModels", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_movieShowModels_movieModels_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModels",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieShowModels_theatreModels_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatreModels",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieShowModels_MovieId",
                table: "movieShowModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieShowModels_TheatreId",
                table: "movieShowModels",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieShowModels");
        }
    }
}
