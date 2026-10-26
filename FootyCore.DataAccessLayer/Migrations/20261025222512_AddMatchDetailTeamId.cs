using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootyCore.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchDetailTeamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "MatchDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetails_TeamId",
                table: "MatchDetails",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchDetails_Teams_TeamId",
                table: "MatchDetails",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchDetails_Teams_TeamId",
                table: "MatchDetails");

            migrationBuilder.DropIndex(
                name: "IX_MatchDetails_TeamId",
                table: "MatchDetails");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "MatchDetails");
        }
    }
}
