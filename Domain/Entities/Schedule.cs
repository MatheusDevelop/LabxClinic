using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Schedule:Entity
    {
        protected Schedule()
        {

        }

        public Schedule(Guid clinicId, Guid medicalSpecialtyId)
        {
            ClinicId = clinicId;
            MedicalSpecialtyId = medicalSpecialtyId;
        }
        public Guid ClinicId { get; private set; }
        public Guid MedicalSpecialtyId { get; private set; }
        public ICollection<AvaibleDate> AvaibleDates { get; private set; }
        public Clinic Clinic { get; private set; }
        public MedicalSpecialty MedicalSpecialty { get; private set; }
    }
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Clinic).WithMany(e => e.Schedules).HasForeignKey(e => e.ClinicId);
            builder.HasOne(e => e.MedicalSpecialty).WithOne(e => e.Schedule).HasForeignKey<Schedule>(e => e.MedicalSpecialtyId);

        }
    }
}
