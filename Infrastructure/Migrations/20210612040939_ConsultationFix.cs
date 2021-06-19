using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ConsultationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Clinic_PacientId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalSpecialty_PacientId",
                table: "Consultations");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_ClinicId",
                table: "Consultations",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedicalSpecialtyId",
                table: "Consultations",
                column: "MedicalSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Clinic_ClinicId",
                table: "Consultations",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalSpecialty_MedicalSpecialtyId",
                table: "Consultations",
                column: "MedicalSpecialtyId",
                principalTable: "MedicalSpecialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Clinic_ClinicId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalSpecialty_MedicalSpecialtyId",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_ClinicId",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_MedicalSpecialtyId",
                table: "Consultations");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Clinic_PacientId",
                table: "Consultations",
                column: "PacientId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalSpecialty_PacientId",
                table: "Consultations",
                column: "PacientId",
                principalTable: "MedicalSpecialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
