using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ClinicMedicalSpecialty
    {
        public ClinicMedicalSpecialty(Guid clinicId, Guid medicalSpecialtyId)
        {
            ClinicId = clinicId;
            MedicalSpecialtyId = medicalSpecialtyId;
        }

        public Guid ClinicId { get; private set; }
        public Guid MedicalSpecialtyId { get; private set; }
        public Clinic Clinic { get; private set; }
        public MedicalSpecialty MedicalSpecialty { get; private set; }
    }
    public class ClinicMedicalSpecialtyMap : IEntityTypeConfiguration<ClinicMedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<ClinicMedicalSpecialty> builder)
        {
            builder.HasKey(e => new { e.ClinicId,e.MedicalSpecialtyId });
            builder.HasOne(e => e.Clinic).WithMany(e => e.ClinicMedicalSpecialties).HasForeignKey(e => e.ClinicId);
            builder.HasOne(e => e.MedicalSpecialty).WithMany(e => e.ClinicMedicalSpecialties).HasForeignKey(e => e.MedicalSpecialtyId);
        }
    }

}
