using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class LinkUserToFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Films",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Films_UserId",
                table: "Films",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_AspNetUsers_UserId",
                table: "Films",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_AspNetUsers_UserId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_UserId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Films");
        }
    }
}
