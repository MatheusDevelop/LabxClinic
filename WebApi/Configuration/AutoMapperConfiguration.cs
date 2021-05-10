using Domain.Mappings.ConsultationMaps;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConsultationMapping));
        }

    }
}
