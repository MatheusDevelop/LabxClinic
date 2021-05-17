using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Doctor:Person
    {
        public Doctor(string document, string name, string profilePicUrl, DateTime birthDate, Guid userId, Guid clinicId) : base(document, name, profilePicUrl, birthDate, userId)
        {
            ClinicId = clinicId;
        }
        public Guid ClinicId { get; private set; }
        public Clinic Clinic { get; private set; }
        public ICollection<DoctorClinicMedicalSpecialty> DoctorClinicMedicalSpecialties { get; set; }
        public ICollection<AvailableDate> AvaibleDates { get; private set; }
        public ICollection<Consultation> Consultations { get; private set; }
    }
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne(e => e.Clinic).WithMany(e => e.Doctors).HasForeignKey(e => e.ClinicId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}