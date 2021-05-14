using Domain.Repositories;
using Domain.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    public class ScheduleInsertValidation:AbstractValidator<ScheduleInsertViewModel>
    {
        public ScheduleInsertValidation(
            IClinicRepository clinicRepository,
            IMedicalSpecialtyRepository medicalSpecialtyRepository)
        {
            

            RuleFor(e => e.MedicalSpecialtyId).NotEmpty()
                .MustAsync(async (id, token) => await medicalSpecialtyRepository.Exists(id))
                .WithMessage("Especialidade médica não encontrada.");
            RuleFor(e => e.ClinicId).NotEmpty()
              .MustAsync(async (id, token) => await clinicRepository.Exists(id))
              .WithMessage("Clínica não encontrada.");

        }
    }
}
