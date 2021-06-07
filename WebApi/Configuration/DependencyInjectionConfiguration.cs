using Domain.Repositories;
using Domain.Services.Implementations;
using Domain.Services.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            AddServices(services);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPacientRepository, PacientRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IClinicMedicalSpecialtyRepository, ClinicMedicalSpecialtyRepository>();
            services.AddScoped<IDoctorClinicMedicalSpecialtyRepository, DoctorClinicMedicalSpecialtyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IMedicalSpecialtyRepository, MedicalSpecialtyRepository>();
            services.AddScoped<IAvaibleDateRepository, AvaibleDateRepository>();
            services.AddScoped<IAllergyRepository, AllergyRepository>();
            services.AddScoped<ISurgeryRepository, SurgeryRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();


        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IDoctorServices, DoctorServices>();
            services.AddScoped<IPacientServices, PacientServices>();
            services.AddScoped<IConsultationServices, ConsultationServices>();
            services.AddScoped<IClinicServices, ClinicServices>();
            services.AddScoped<IClinicMedicalSpecialtyServices, ClinicMedicalSpecialtyServices>();
            services.AddScoped<IDoctorClinicMedicalSpecialtyServices, DoctorClinicMedicalSpecialtyServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAllergyServices, AllergyServices>();
            services.AddScoped<IMedicalSpecialtyServices, MedicalSpecialtyServices>();
            services.AddScoped<IScheduleServices, ScheduleServices>();
            services.AddScoped<IAddressServices, AddressServices>();
            services.AddScoped<IAvaibleDateServices, AvailableDateServices>();
            services.AddScoped<ISurgeryServices, SurgeryServices>();
            services.AddScoped<IExamServices, ExamServices>();



        }
    }
}
