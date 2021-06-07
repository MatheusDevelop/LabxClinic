using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Allergy:Entity
    {
        public Allergy(string name, Guid pacientId)
        {
            Name = name;
            PacientId = pacientId;
        }
        public Guid PacientId { get; private set; }
        public Pacient Pacient { get; set; }
        public string Name { get; private set; }
    }
    public class AllergyMap : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Pacient).WithMany(e => e.Allergies).HasForeignKey(e => e.PacientId);
        }
    }
}
