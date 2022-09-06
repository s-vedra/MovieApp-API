using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DataAccess.Migrations
{
    public partial class modelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_User_UserId",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_MovieList_UserId",
                table: "MovieList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieList");

            migrationBuilder.AddColumn<int>(
                name: "UserDtoId",
                table: "MovieList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieList_UserDtoId",
                table: "MovieList",
                column: "UserDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_User_UserDtoId",
                table: "MovieList",
                column: "UserDtoId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_User_UserDtoId",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_MovieList_UserDtoId",
                table: "MovieList");

            migrationBuilder.DropColumn(
                name: "UserDtoId",
                table: "MovieList");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieList_UserId",
                table: "MovieList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_User_UserId",
                table: "MovieList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
