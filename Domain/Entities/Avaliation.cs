using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Avaliation:Entity
    {
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Comment { get; set; }
        public int Note { get; set; }
    
    }
    public class AvaliationMap : IEntityTypeConfiguration<Avaliation>
    {
        public void Configure(EntityTypeBuilder<Avaliation> builder)
        {
            builder.HasOne(e => e.Doctor).WithMany(e => e.Avaliations).HasForeignKey(e => e.DoctorId);
        }
    }
}
