using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Ratingsv9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Movies_MovieID",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Shows_ShowID",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_UserID",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserID",
                table: "Ratings",
                newName: "IX_Ratings_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_ShowID",
                table: "Ratings",
                newName: "IX_Ratings_ShowID");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_MovieID",
                table: "Ratings",
                newName: "IX_Ratings_MovieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieID",
                table: "Ratings",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Shows_ShowID",
                table: "Ratings",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserID",
                table: "Ratings",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieID",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Shows_ShowID",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserID",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserID",
                table: "Rating",
                newName: "IX_Rating_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ShowID",
                table: "Rating",
                newName: "IX_Rating_ShowID");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MovieID",
                table: "Rating",
                newName: "IX_Rating_MovieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_UserID",
                table: "Rating",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
