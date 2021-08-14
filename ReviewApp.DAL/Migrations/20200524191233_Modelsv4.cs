using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Modelsv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundURL",
                table: "Shows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundURL",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundURL",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "BackgroundURL",
                table: "Movies");
        }
    }
}
