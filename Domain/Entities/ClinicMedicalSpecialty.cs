using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ClinicMedicalSpecialty:Entity
    {
        public ClinicMedicalSpecialty(Guid clinicId, Guid medicalSpecialtyId)
        {
            ClinicId = clinicId;
            MedicalSpecialtyId = medicalSpecialtyId;
        }
        public ICollection<DoctorClinicMedicalSpecialty> DoctorClinicMedicalSpecialties { get; private set; }
        public Guid ClinicId { get; private set; }
        public Guid MedicalSpecialtyId { get; private set; }
        public Clinic Clinic { get; private set; }
        public MedicalSpecialty MedicalSpecialty { get; private set; }
    }
    public class ClinicMedicalSpecialtyMap : IEntityTypeConfiguration<ClinicMedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<ClinicMedicalSpecialty> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Clinic).WithMany(e => e.ClinicMedicalSpecialties).HasForeignKey(e => e.ClinicId);
            builder.HasOne(e => e.MedicalSpecialty).WithMany(e => e.ClinicMedicalSpecialties).HasForeignKey(e => e.MedicalSpecialtyId);
        }
    }

}
