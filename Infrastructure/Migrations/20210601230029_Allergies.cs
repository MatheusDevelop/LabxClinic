using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Allergies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlreadyFainted",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AlreadyHadAvc",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HaveWalkingDifficulty",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_Person_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surgeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surgeries_Person_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_PacientId",
                table: "Allergies",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_PacientId",
                table: "Surgeries",
                column: "PacientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Surgeries");

            migrationBuilder.DropColumn(
                name: "AlreadyFainted",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AlreadyHadAvc",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "HaveWalkingDifficulty",
                table: "Person");
        }
    }
}
