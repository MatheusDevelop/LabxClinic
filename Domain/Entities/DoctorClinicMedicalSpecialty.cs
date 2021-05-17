using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class DoctorClinicMedicalSpecialty:Entity
    {
        public Guid ClinicMedicalSpecialtyId { get; private set; }
        public ClinicMedicalSpecialty ClinicMedicalSpecialty { get; private set; }
        public Guid DoctorId { get; private set; }
        public Doctor Doctor { get; private set; }
    }
    public class DoctorClinicMedicalSpecialtyMap : IEntityTypeConfiguration<DoctorClinicMedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<DoctorClinicMedicalSpecialty> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Doctor).WithMany(e => e.DoctorClinicMedicalSpecialties).HasForeignKey(e => e.DoctorId);
            builder.HasOne(e => e.ClinicMedicalSpecialty).WithMany(e => e.DoctorClinicMedicalSpecialties).HasForeignKey(e => e.ClinicMedicalSpecialtyId);
        }
    }


}
