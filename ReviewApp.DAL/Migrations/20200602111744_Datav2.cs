using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewApp.Data.Migrations
{
    public partial class Datav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "CountryOfBirth", "DateOfBirth", "Description", "FirstName", "Gender", "LastName", "PictureURL", "PlaceOfBirth" },
                values: new object[] { 999, "Australia", null, "Peter Weir was born on August 21, 1944 in Sydney, New South Wales, Australia as Peter Lindsay Weir. He is a director and writer, known for Master and Commander: The Far Side of the World (2003), The Way Back (2010) and The Truman Show (1998). He has been married to Wendy Stites since 1966. They have two children.", "Peter", "M", "Weir", null, "Sydney" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "BackgroundURL", "CountryOfRelease", "DirectorID", "DurationMinutes", "PictureURL", "ReleaseDate", "Synopsis", "Title", "TrailerURL" },
                values: new object[] { 9999, null, "USA", 999, 103, null, new DateTime(1998, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "An insurance salesman discovers his whole life is actually a reality TV show. ", "The Truman Show", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 9999);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 999);
        }
    }
}
