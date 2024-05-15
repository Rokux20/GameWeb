using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameWeb.Migrations
{
    /// <inheritdoc />
    public partial class fixtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Game_FarmId",
                table: "Game",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_UserId",
                table: "Game",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Farms_FarmId",
                table: "Game",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_UserId",
                table: "Game",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Farms_FarmId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_UserId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_FarmId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserId",
                table: "Game");
        }
    }
}
