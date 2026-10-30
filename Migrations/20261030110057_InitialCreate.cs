using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zenestudio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eloadok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Muvesznev = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eloadok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZeneiProjektek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cim = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    EloadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Stilus = table.Column<string>(type: "TEXT", nullable: false),
                    BPM = table.Column<int>(type: "INTEGER", nullable: false),
                    Statusz = table.Column<string>(type: "TEXT", nullable: false),
                    LetrehozasDatum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZeneiProjektek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZeneiProjektek_Eloadok_EloadoId",
                        column: x => x.EloadoId,
                        principalTable: "Eloadok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Savok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjektId = table.Column<int>(type: "INTEGER", nullable: false),
                    SavNev = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Hangszer = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    HosszMasodperc = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Savok_ZeneiProjektek_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "ZeneiProjektek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Savok_ProjektId",
                table: "Savok",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_ZeneiProjektek_EloadoId",
                table: "ZeneiProjektek",
                column: "EloadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Savok");

            migrationBuilder.DropTable(
                name: "ZeneiProjektek");

            migrationBuilder.DropTable(
                name: "Eloadok");
        }
    }
}
