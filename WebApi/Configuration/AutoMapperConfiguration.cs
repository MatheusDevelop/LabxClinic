using Domain.Mappings;
using Domain.Mappings.ConsultationMaps;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ConsultationMapping),
                typeof(MedicalSpecialtyMapping),
                typeof(ClinicMapping),
                typeof(AddressMapping),
                typeof(ScheduleMapping),
                typeof(AvaibleDateMapping),
                typeof(DoctorMapping),
                typeof(ClinicMedicalSpecialtyMapping),
                typeof(DoctorClinicMedicalSpecialtyMapping)

                )
                ;
        }

    }
}
