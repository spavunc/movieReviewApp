using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Modelsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterActors_Person_ActorId",
                table: "CharacterActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Person_ActorId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Person_DirectorID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieWriters_Person_WriterId",
                table: "MovieWriters");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowActors_Person_ActorId",
                table: "ShowActors");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowWriters_Person_WriterId",
                table: "ShowWriters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterActors_People_ActorId",
                table: "CharacterActors",
                column: "ActorId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_People_ActorId",
                table: "MovieActors",
                column: "ActorId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_People_DirectorID",
                table: "Movies",
                column: "DirectorID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieWriters_People_WriterId",
                table: "MovieWriters",
                column: "WriterId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowActors_People_ActorId",
                table: "ShowActors",
                column: "ActorId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowWriters_People_WriterId",
                table: "ShowWriters",
                column: "WriterId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterActors_People_ActorId",
                table: "CharacterActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_People_ActorId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_People_DirectorID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieWriters_People_WriterId",
                table: "MovieWriters");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowActors_People_ActorId",
                table: "ShowActors");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowWriters_People_WriterId",
                table: "ShowWriters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterActors_Person_ActorId",
                table: "CharacterActors",
                column: "ActorId",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Person_ActorId",
                table: "MovieActors",
                column: "ActorId",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Person_DirectorID",
                table: "Movies",
                column: "DirectorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieWriters_Person_WriterId",
                table: "MovieWriters",
                column: "WriterId",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowActors_Person_ActorId",
                table: "ShowActors",
                column: "ActorId",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowWriters_Person_WriterId",
                table: "ShowWriters",
                column: "WriterId",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
