using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pacient:Person
    {
        protected Pacient()
        {

        }
        public Pacient(string docoment, string name, string profilePicUrl, DateTime birthDate, Guid userId, string description) : base(docoment, name, profilePicUrl, birthDate, userId, description)
        {
        }
        public Guid InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
        public string BloodType { get; private set; }
        public bool AlreadyHadAvc { get; private set; }
        public bool AlreadyFainted { get; private set; }
        public bool HaveWalkingDifficulty { get; private set; }
        public ICollection<Allergy> Allergies { get; private set; }
        public ICollection<Surgery> Surgeries { get; private set; }
        public ICollection<Exam> Exams { get; private set; }
        public ICollection<Consultation> Consultations { get; private set; }
    }
    public class PacientMap : IEntityTypeConfiguration<Pacient>
    {
        public void Configure(EntityTypeBuilder<Pacient> builder)
        {
            builder.HasOne(e => e.Insurance).WithMany(e => e.Pacients).HasForeignKey(e => e.InsuranceId);
        }
    }
}