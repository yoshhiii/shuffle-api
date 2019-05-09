using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shuffle.Data.Migrations
{
    public partial class AddingNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ruleset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruleset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChallengerId = table.Column<int>(nullable: true),
                    OppositionId = table.Column<int>(nullable: true),
                    ChallengerScore = table.Column<int>(nullable: true),
                    OppositionScore = table.Column<int>(nullable: true),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    RulesetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_ChallengerId",
                        column: x => x.ChallengerId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_OppositionId",
                        column: x => x.OppositionId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Ruleset_RulesetId",
                        column: x => x.RulesetId,
                        principalTable: "Ruleset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(nullable: false),
                    RulesetId = table.Column<int>(nullable: false),
                    Elo = table.Column<int>(nullable: false, defaultValue: 1500),
                    Wins = table.Column<int>(nullable: false, defaultValue: 0),
                    Losses = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamRecord_Ruleset_RulesetId",
                        column: x => x.RulesetId,
                        principalTable: "Ruleset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamRecord_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTeams",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_UserTeams_User_TeamId",
                        column: x => x.TeamId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTeams_Team_UserId",
                        column: x => x.UserId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_ChallengerId",
                table: "Match",
                column: "ChallengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_OppositionId",
                table: "Match",
                column: "OppositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RulesetId",
                table: "Match",
                column: "RulesetId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRecord_RulesetId",
                table: "TeamRecord",
                column: "RulesetId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRecord_TeamId",
                table: "TeamRecord",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_TeamId",
                table: "UserTeams",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "TeamRecord");

            migrationBuilder.DropTable(
                name: "UserTeams");

            migrationBuilder.DropTable(
                name: "Ruleset");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
