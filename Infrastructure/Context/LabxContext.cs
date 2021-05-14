using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Context
{
    public class LabxContext : DbContext
    {
        public LabxContext(DbContextOptions<LabxContext> options) : base(options)
        { }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Pacient> Pacient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialty { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<ClinicAddress> ClinicAddress { get; set; }
        public DbSet<ClinicMedicalSpecialty> ClinicMedicalSpecialty { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<AvaibleDate> AvaibleDate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConsultationMap());
            modelBuilder.ApplyConfiguration(new MedicalSpecialtyMap());
            modelBuilder.ApplyConfiguration(new ClinicMap());
            modelBuilder.ApplyConfiguration(new ClinicAddressMap());
            modelBuilder.ApplyConfiguration(new ScheduleMap());
            modelBuilder.ApplyConfiguration(new AvaibleDateMap());
            modelBuilder.ApplyConfiguration(new ClinicMedicalSpecialtyMap());



        }
    }
}
