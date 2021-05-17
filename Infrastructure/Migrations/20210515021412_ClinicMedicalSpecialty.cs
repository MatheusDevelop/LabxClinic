using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ClinicMedicalSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicMedicalSpecialty",
                table: "ClinicMedicalSpecialty");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ClinicMedicalSpecialty",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ClinicMedicalSpecialty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ClinicMedicalSpecialty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ClinicMedicalSpecialty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicMedicalSpecialty",
                table: "ClinicMedicalSpecialty",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicMedicalSpecialty_ClinicId",
                table: "ClinicMedicalSpecialty",
                column: "ClinicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicMedicalSpecialty",
                table: "ClinicMedicalSpecialty");

            migrationBuilder.DropIndex(
                name: "IX_ClinicMedicalSpecialty_ClinicId",
                table: "ClinicMedicalSpecialty");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClinicMedicalSpecialty");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ClinicMedicalSpecialty");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ClinicMedicalSpecialty");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ClinicMedicalSpecialty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicMedicalSpecialty",
                table: "ClinicMedicalSpecialty",
                columns: new[] { "ClinicId", "MedicalSpecialtyId" });
        }
    }
}
