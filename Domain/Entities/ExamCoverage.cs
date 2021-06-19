using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ExamCoverage:Entity
    {
        public ExamCoverage(Guid insuranceId, string name)
        {
            InsuranceId = insuranceId;
            Name = name;
        }

        public Guid InsuranceId { get; private set; }
        public string Name { get; private set; }
        public Insurance Insurance { get; private set; }
    }
    public class ExamCoverageMap : IEntityTypeConfiguration<ExamCoverage>
    {
        public void Configure(EntityTypeBuilder<ExamCoverage> builder)
        {
            builder.HasOne(e => e.Insurance).WithMany(e => e.ExamsCoverages).HasForeignKey(e => e.InsuranceId);
        }
    }
}
