using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

    }
}
