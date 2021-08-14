using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Modelsv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EpisodeDuration",
                table: "Shows",
                newName: "EpisodeDurationInt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EpisodeDurationInt",
                table: "Shows",
                newName: "EpisodeDuration");
        }
    }
}
