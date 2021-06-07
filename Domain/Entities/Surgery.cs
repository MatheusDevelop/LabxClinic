using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Surgery:Entity
    {
        public Surgery(string name, Guid pacientId)
        {
            Name = name;
            PacientId = pacientId;
        }
        public Guid PacientId { get; private set; }
        public Pacient Pacient { get; private set; }
        public string Name { get; private set; }
    }
    public class SurgeryMap : IEntityTypeConfiguration<Surgery>
    {
        public void Configure(EntityTypeBuilder<Surgery> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Pacient).WithMany(e => e.Surgeries).HasForeignKey(e => e.PacientId);
        }
    }
}
