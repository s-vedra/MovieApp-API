using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DataAccess.Migrations
{
    public partial class switchdto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_Movie_MovieDtoId",
                table: "MovieList");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_User_UserDtoId",
                table: "MovieList");

            migrationBuilder.RenameColumn(
                name: "UserDtoId",
                table: "MovieList",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MovieDtoId",
                table: "MovieList",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieList_UserDtoId",
                table: "MovieList",
                newName: "IX_MovieList_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_User_UserId",
                table: "MovieList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_Movie_MovieId",
                table: "MovieList");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_User_UserId",
                table: "MovieList");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MovieList",
                newName: "UserDtoId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieList",
                newName: "MovieDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieList_UserId",
                table: "MovieList",
                newName: "IX_MovieList_UserDtoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_User_UserDtoId",
                table: "MovieList",
                column: "UserDtoId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
