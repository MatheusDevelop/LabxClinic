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
        public DbSet<DoctorClinicMedicalSpecialty> DoctorClinicMedicalSpecialty { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<AvailableDate> AvaibleDate { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Avaliation> Avaliations { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<ExamCoverage> ExamCoverages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConsultationMap());
            modelBuilder.ApplyConfiguration(new MedicalSpecialtyMap());
            modelBuilder.ApplyConfiguration(new ClinicMap());
            modelBuilder.ApplyConfiguration(new ClinicAddressMap());
            modelBuilder.ApplyConfiguration(new AvaibleDateMap());
            modelBuilder.ApplyConfiguration(new ClinicMedicalSpecialtyMap());
            modelBuilder.ApplyConfiguration(new DoctorClinicMedicalSpecialtyMap());
            modelBuilder.ApplyConfiguration(new DoctorMap());
            modelBuilder.ApplyConfiguration(new AllergyMap());
            modelBuilder.ApplyConfiguration(new SurgeryMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ExamMap());
            modelBuilder.ApplyConfiguration(new PacientMap());
            modelBuilder.ApplyConfiguration(new ExamCoverageMap());
            modelBuilder.ApplyConfiguration(new AvaliationMap());


        }
    }
}
