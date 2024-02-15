using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleTracker.Migrations
{
    public partial class GameSubEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Character_GameId",
                table: "Character",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Game_GameId",
                table: "Character",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Game_GameId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_GameId",
                table: "Character");
        }
    }
}
