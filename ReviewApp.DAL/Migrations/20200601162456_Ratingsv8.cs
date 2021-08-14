using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Ratingsv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Movies_MovieID",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Shows_ShowID",
                table: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "ShowID",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Movies_MovieID",
                table: "Rating",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Shows_ShowID",
                table: "Rating",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Movies_MovieID",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Shows_ShowID",
                table: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "ShowID",
                table: "Rating",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Rating",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Movies_MovieID",
                table: "Rating",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Shows_ShowID",
                table: "Rating",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
