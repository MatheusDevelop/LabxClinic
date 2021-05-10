using Domain.Repositories;
using Domain.Services.Implementations;
using Domain.Services.Interfaces;
using Domain.Validations;
using FluentValidation.AspNetCore;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(e =>
                {
                    e.RegisterValidatorsFromAssemblyContaining<ConsultationInsertValidation>();
                }
                );
        }

    }
}
