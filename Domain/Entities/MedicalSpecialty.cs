using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MedicalSpecialty:Entity
    {
        protected MedicalSpecialty()
        {

        }
        public MedicalSpecialty(string name, string picUrl)
        {
            Name = name;
            PicUrl = picUrl;
        }

        public string Name { get; private set; }
        public string PicUrl { get; private set; }
        public ICollection<Consultation> Consultations { get; private set; }
    }
    public class MedicalSpecialtyMap : IEntityTypeConfiguration<MedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<MedicalSpecialty> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(70).IsRequired();
        }
    }
}