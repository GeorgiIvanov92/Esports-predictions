using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoLData.Migrations
{
    public partial class SportsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prelive",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportId = table.Column<int>(type: "int", nullable: true),
                    HomeTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BestOf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prelive", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportId = table.Column<int>(type: "int", nullable: true),
                    HomeTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: true),
                    AwayScore = table.Column<int>(type: "int", nullable: true),
                    GamePart = table.Column<int>(type: "int", nullable: true),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Winrate = table.Column<float>(type: "real", nullable: false),
                    AverageGameTime = table.Column<float>(type: "real", nullable: false),
                    GoldPerMinute = table.Column<int>(type: "int", nullable: false),
                    GoldDifferencePerMinute = table.Column<int>(type: "int", nullable: false),
                    GoldDifferenceAt15 = table.Column<int>(type: "int", nullable: false),
                    CSPerMinute = table.Column<float>(type: "real", nullable: false),
                    CSDifferenceAt15 = table.Column<float>(type: "real", nullable: false),
                    TowerDifferenceAt15 = table.Column<float>(type: "real", nullable: false),
                    FirstTowerPercent = table.Column<int>(type: "int", nullable: false),
                    DragonsPerGame = table.Column<float>(type: "real", nullable: false),
                    DragonsAt15 = table.Column<float>(type: "real", nullable: false),
                    HeraldPerGame = table.Column<float>(type: "real", nullable: false),
                    NashorsPerGame = table.Column<float>(type: "real", nullable: false),
                    DamagePerMinute = table.Column<int>(type: "int", nullable: false),
                    FirstBloodPercent = table.Column<int>(type: "int", nullable: false),
                    KillsPerGame = table.Column<float>(type: "real", nullable: false),
                    DeathsPerGame = table.Column<float>(type: "real", nullable: false),
                    KDRatio = table.Column<float>(type: "real", nullable: false),
                    WardsPerMinute = table.Column<float>(type: "real", nullable: false),
                    VisionWardsPerMinute = table.Column<float>(type: "real", nullable: false),
                    WardsClearedPerMinute = table.Column<float>(type: "real", nullable: false),
                    WardsClearedPercent = table.Column<float>(type: "real", nullable: false),
                    CloudDrakesKilled = table.Column<int>(type: "int", nullable: false),
                    CloudDrakesLost = table.Column<int>(type: "int", nullable: false),
                    OceanDrakesKilled = table.Column<int>(type: "int", nullable: false),
                    OceanDrakesLost = table.Column<int>(type: "int", nullable: false),
                    InfernalDrakesKilled = table.Column<int>(type: "int", nullable: false),
                    InfernalDrakesLost = table.Column<int>(type: "int", nullable: false),
                    MountainDrakesKilled = table.Column<int>(type: "int", nullable: false),
                    MountainDrakesLost = table.Column<int>(type: "int", nullable: false),
                    HextechDrakesKilled = table.Column<int>(type: "int", nullable: false),
                    HextechDrakesLost = table.Column<int>(type: "int", nullable: false),
                    ChemtechDrakesKilled = table.Column<int>(type: "int", nullable: false),
                    ChemtechDrakesLost = table.Column<int>(type: "int", nullable: false),
                    ElderDrakesKilled = table.Column<int>(type: "int", nullable: false),
                    ElderDrakesLost = table.Column<int>(type: "int", nullable: false),
                    BlueSideWins = table.Column<int>(type: "int", nullable: false),
                    BlueSideLosses = table.Column<int>(type: "int", nullable: false),
                    RedSideWins = table.Column<int>(type: "int", nullable: false),
                    RedSideLosses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    KDA = table.Column<float>(type: "real", nullable: false),
                    CSPerMinute = table.Column<float>(type: "real", nullable: false),
                    GoldPerMinute = table.Column<float>(type: "real", nullable: false),
                    GoldPercent = table.Column<float>(type: "real", nullable: false),
                    KillParticipation = table.Column<float>(type: "real", nullable: false),
                    DamagePerMinute = table.Column<float>(type: "real", nullable: false),
                    DamagePercent = table.Column<float>(type: "real", nullable: false),
                    KillsAndAssistsPerMinute = table.Column<float>(type: "real", nullable: false),
                    SoloKills = table.Column<int>(type: "int", nullable: false),
                    Pentakills = table.Column<int>(type: "int", nullable: false),
                    VisionScorePerMinute = table.Column<float>(type: "real", nullable: false),
                    WardPerMinute = table.Column<float>(type: "real", nullable: false),
                    VisionWardsPerMinute = table.Column<float>(type: "real", nullable: false),
                    WardsClearedPerMinute = table.Column<float>(type: "real", nullable: false),
                    AheadInCSAt15Percent = table.Column<float>(type: "real", nullable: false),
                    CSDifferenceAt15 = table.Column<float>(type: "real", nullable: false),
                    GoldDifferenceAt15 = table.Column<float>(type: "real", nullable: false),
                    XPDifferenceAt15 = table.Column<float>(type: "real", nullable: false),
                    FirstBloodParticipationPercent = table.Column<float>(type: "real", nullable: false),
                    FirstBloodVictimPercent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampionStat",
                columns: table => new
                {
                    ChampionStatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    KDA = table.Column<double>(type: "float", nullable: false),
                    WinratePercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionStat", x => x.ChampionStatId);
                    table.ForeignKey(
                        name: "FK_ChampionStat_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionStat_PlayerId",
                table: "ChampionStat",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionStat");

            migrationBuilder.DropTable(
                name: "Prelive");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
