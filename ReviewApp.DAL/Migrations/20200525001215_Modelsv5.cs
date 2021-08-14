using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Modelsv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MovieID",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Shows_ShowID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MovieID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_ShowID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ShowID",
                table: "Genres");

            migrationBuilder.AlterColumn<float>(
                name: "AverageScore",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EpisodeDuration",
                table: "Shows",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEpisodes",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "AverageScore",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Movies",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowGenres",
                columns: table => new
                {
                    ShowId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowGenres", x => new { x.GenreId, x.ShowId });
                    table.ForeignKey(
                        name: "FK_ShowGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowGenres_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowGenres_ShowId",
                table: "ShowGenres",
                column: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "ShowGenres");

            migrationBuilder.DropColumn(
                name: "EpisodeDuration",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "NumberOfEpisodes",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Movies");

            migrationBuilder.AlterColumn<double>(
                name: "AverageScore",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "AverageScore",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Genres",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShowID",
                table: "Genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MovieID",
                table: "Genres",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ShowID",
                table: "Genres",
                column: "ShowID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_MovieID",
                table: "Genres",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Shows_ShowID",
                table: "Genres",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
