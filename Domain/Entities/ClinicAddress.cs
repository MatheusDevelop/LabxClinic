using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ClinicAddress:Address
    {
        protected ClinicAddress()
        {

        }
        public ClinicAddress(Clinic clinic)
        {
            Clinic = clinic;
        }
        public ClinicAddress(Guid clinicId)
        {
            ClinicId = clinicId;
        }
        public Guid ClinicId { get; private set; }
        public Clinic Clinic { get; private set; }
       
    }
    public class ClinicAddressMap : IEntityTypeConfiguration<ClinicAddress>
    {
        public void Configure(EntityTypeBuilder<ClinicAddress> builder)
        {
            builder.HasOne(e => e.Clinic).WithOne(e => e.ClinicAddress).HasForeignKey<ClinicAddress>(e => e.ClinicId);
        }
    }
}
