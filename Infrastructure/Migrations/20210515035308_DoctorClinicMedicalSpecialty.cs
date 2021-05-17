using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class DoctorClinicMedicalSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoctorClinicMedicalSpecialty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicMedicalSpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorClinicMedicalSpecialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorClinicMedicalSpecialty_ClinicMedicalSpecialty_ClinicMedicalSpecialtyId",
                        column: x => x.ClinicMedicalSpecialtyId,
                        principalTable: "ClinicMedicalSpecialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorClinicMedicalSpecialty_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_ClinicId",
                table: "Person",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinicMedicalSpecialty_ClinicMedicalSpecialtyId",
                table: "DoctorClinicMedicalSpecialty",
                column: "ClinicMedicalSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinicMedicalSpecialty_DoctorId",
                table: "DoctorClinicMedicalSpecialty",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Clinic_ClinicId",
                table: "Person",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Clinic_ClinicId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "DoctorClinicMedicalSpecialty");

            migrationBuilder.DropIndex(
                name: "IX_Person_ClinicId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Person");
        }
    }
}
