using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AvailableDate:Entity
    {
        protected AvailableDate()
        {

        }
        public AvailableDate(Guid scheduleId, DateTime date, Guid doctorId)
        {
            ScheduleId = scheduleId;
            Date = date;
            DoctorId = doctorId;
        }
        public Guid ScheduleId { get; private set; }
        public Guid DoctorId { get; private set; }
        public DateTime Date { get; private set; }
        public Schedule Schedule { get; private set; }
        public Doctor Doctor { get; private set; }
    }
    public class AvaibleDateMap : IEntityTypeConfiguration<AvailableDate>
    {
        public void Configure(EntityTypeBuilder<AvailableDate> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Schedule).WithMany(e => e.AvaibleDates).HasForeignKey(e => e.ScheduleId);
            builder.HasOne(e => e.Doctor).WithMany(e => e.AvaibleDates).HasForeignKey(e => e.DoctorId);
        }
    }
}
