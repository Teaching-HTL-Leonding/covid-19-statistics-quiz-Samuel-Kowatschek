using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidStats.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bundeslands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundeslands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bezirks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BundeslandID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bezirks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bezirks_Bundeslands_BundeslandID",
                        column: x => x.BundeslandID,
                        principalTable: "Bundeslands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BezirkID = table.Column<int>(type: "int", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Infections = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Incidences = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cases_Bezirks_BezirkID",
                        column: x => x.BezirkID,
                        principalTable: "Bezirks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bezirks_BundeslandID",
                table: "Bezirks",
                column: "BundeslandID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_BezirkID",
                table: "Cases",
                column: "BezirkID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Bezirks");

            migrationBuilder.DropTable(
                name: "Bundeslands");
        }
    }
}
