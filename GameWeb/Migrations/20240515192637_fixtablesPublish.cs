using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameWeb.Migrations
{
    /// <inheritdoc />
    public partial class fixtablesPublish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_UserId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserId",
                table: "Game");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Game_UserId",
                table: "Game",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_UserId",
                table: "Game",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
