using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Consultation:Entity
    {
        protected Consultation() { }
        public Consultation(Guid doctorId,
            Guid pacientId,
            DateTime consultationDate,
            Guid medicalSpecialtyId,
            Guid clinicId, string consultationName)
        {
            DoctorId = doctorId;
            PacientId = pacientId;
            ConsultationDate = consultationDate;
            MedicalSpecialtyId = medicalSpecialtyId;
            ClinicId = clinicId;
            ConsultationName = consultationName;
        }

        public Consultation(Doctor doctor, Pacient pacient, DateTime consultationDate, MedicalSpecialty medicalSpecialty, Clinic clinic, string consultationName)
        {
            Doctor = doctor;
            Pacient = pacient;
            ConsultationDate = consultationDate;
            MedicalSpecialty = medicalSpecialty;
            Clinic = clinic;
            ConsultationName = consultationName;
        }
        public string ConsultationName { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid PacientId { get; private set; }
        public Guid MedicalSpecialtyId { get; private set; }
        public Guid ClinicId { get; private set; }
        public Doctor Doctor { get; private set; }
        public Pacient Pacient { get; private set; }
        public DateTime ConsultationDate  { get; private set; }
        public MedicalSpecialty MedicalSpecialty { get; private set; }
        public Clinic Clinic { get; private set; }
        public bool IsForwarding { get; private set; }
        public void RescheduleConsultation(DateTime newDate) 
        {
            ConsultationDate = newDate;
            IsForwarding = false;
        }
        public void SetToForwarding() { IsForwarding = true; }
    }
    public class ConsultationMap : IEntityTypeConfiguration<Consultation>
    {
        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Doctor)
                   .WithMany(e => e.Consultations)
                   .HasForeignKey(e=> e.DoctorId);

            builder.Property(e => e.ConsultationName).HasMaxLength(100)
                .IsRequired();
            builder.HasOne(e => e.Pacient)
                   .WithMany(e => e.Consultations)
                   .HasForeignKey(e => e.PacientId);

            builder.HasOne(e => e.MedicalSpecialty)
                   .WithMany(e => e.Consultations)
                   .HasForeignKey(e => e.PacientId);

            builder.HasOne(e => e.Clinic)
                   .WithMany(e => e.Consultations)
                   .HasForeignKey(e => e.PacientId);


        }
    }
}
