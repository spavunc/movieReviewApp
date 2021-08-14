using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Modelsv9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeDuration",
                table: "Shows",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpisodeDuration",
                table: "Shows");
        }
    }
}
