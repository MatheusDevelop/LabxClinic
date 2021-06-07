using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Pacients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Pacient_PacientId",
                table: "Consultations");

            migrationBuilder.DropTable(
                name: "Pacient");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Person_PacientId",
                table: "Consultations",
                column: "PacientId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Person_PacientId",
                table: "Consultations");

            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Pacient_PacientId",
                table: "Consultations",
                column: "PacientId",
                principalTable: "Pacient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
