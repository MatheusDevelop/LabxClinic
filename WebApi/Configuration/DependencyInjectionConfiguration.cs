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

            services.AddScoped<IMedicalSpecialtyRepository, MedicalSpecialtyRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IDoctorServices, DoctorServices>();
            services.AddScoped<IPacientServices, PacientServices>();
            services.AddScoped<IConsultationServices, ConsultationServices>();

            services.AddScoped<IMedicalSpecialtyServices, MedicalSpecialtyServices>();
        }
    }
}
