using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Clinic:Entity
    {
        public string Name { get; private set; }
        public string PicUrl { get; private set; }
        public ClinicAddress ClinicAddress { get; private set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<ClinicMedicalSpecialty> ClinicMedicalSpecialties { get; private set; }
        public ICollection<Schedule> Schedules { get; private set; }
        public ICollection<Consultation> Consultations { get; private set; }

        public Clinic(string name, string picUrl)
        {
            Name = name;
            PicUrl = picUrl;
        }

        public Clinic(string name, string picUrl, ClinicAddress clinicAddress)
        {
            Name = name;
            PicUrl = picUrl;
            ClinicAddress = clinicAddress;
        }
    }
    public class ClinicMap : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(150).IsRequired();
            
        }
    }
}