using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Ratingsv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_UserId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Rating",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                newName: "IX_Rating_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_UserID",
                table: "Rating",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_UserID",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Rating",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserID",
                table: "Rating",
                newName: "IX_Rating_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
