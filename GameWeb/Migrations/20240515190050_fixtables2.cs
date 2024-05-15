using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameWeb.Migrations
{
    /// <inheritdoc />
    public partial class fixtables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Farms_FarmId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_FarmId",
                table: "Game");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Game_FarmId",
                table: "Game",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Farms_FarmId",
                table: "Game",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
