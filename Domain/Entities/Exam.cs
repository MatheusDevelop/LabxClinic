using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Exam:Entity
    {
        protected Exam()
        {

        }
        public Exam(
            bool pendency,
            DateTime? previsionDate,
            string name,
            string fileUrl,
            Guid pacientId,
            Guid doctorId)
        {
            Pendency = pendency;
            PrevisionDate = previsionDate;
            Name = name;
            FileUrl = fileUrl;
            PacientId = pacientId;
            DoctorId = doctorId;
        }

        public bool Pendency { get; private set; }
        public DateTime? PrevisionDate { get; private set; }
        public string Name { get; private  set; }
        public string FileUrl { get; private set; }
        public string Description { get; private set; }
        public Guid PacientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public Pacient Pacient { get; private set; }
        public Doctor Doctor { get; private set; }
    }
    public class ExamMap : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Doctor).WithMany(e => e.Exams).HasForeignKey(e => e.DoctorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Pacient).WithMany(e => e.Exams).HasForeignKey(e => e.PacientId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(e => e.PrevisionDate).IsRequired(false);
        }
    }
}
