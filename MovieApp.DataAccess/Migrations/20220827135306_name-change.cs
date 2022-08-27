using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DataAccess.Migrations
{
    public partial class namechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_Movie_MovieId",
                table: "MovieList");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieList",
                newName: "MovieDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieList_MovieId",
                table: "MovieList",
                newName: "IX_MovieList_MovieDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_Movie_MovieDtoId",
                table: "MovieList",
                column: "MovieDtoId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_Movie_MovieDtoId",
                table: "MovieList");

            migrationBuilder.RenameColumn(
                name: "MovieDtoId",
                table: "MovieList",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieList_MovieDtoId",
                table: "MovieList",
                newName: "IX_MovieList_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_Movie_MovieId",
                table: "MovieList",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
