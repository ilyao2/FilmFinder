using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmFinder.Migrations
{
    public partial class RenameGanreToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Genre_ganreid",
                table: "Film");

            migrationBuilder.DropIndex(
                name: "IX_Film_ganreid",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "ganreid",
                table: "Film");

            migrationBuilder.AddColumn<int>(
                name: "genreid",
                table: "Film",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Film_genreid",
                table: "Film",
                column: "genreid");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Genre_genreid",
                table: "Film",
                column: "genreid",
                principalTable: "Genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Genre_genreid",
                table: "Film");

            migrationBuilder.DropIndex(
                name: "IX_Film_genreid",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "genreid",
                table: "Film");

            migrationBuilder.AddColumn<int>(
                name: "ganreid",
                table: "Film",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Film_ganreid",
                table: "Film",
                column: "ganreid");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Genre_ganreid",
                table: "Film",
                column: "ganreid",
                principalTable: "Genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
