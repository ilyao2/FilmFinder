using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmFinder.Migrations
{
    public partial class addimgforfilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgPath",
                table: "Film",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgPath",
                table: "Film");
        }
    }
}
