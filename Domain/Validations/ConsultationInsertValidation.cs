using Domain.Repositories;
using Domain.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    public class ConsultationInsertValidation:AbstractValidator<ConsultationInsertViewModel>
    {
        public ConsultationInsertValidation(
            IMedicalSpecialtyRepository medicalSpecialtyRepository,
            IDoctorRepository doctorRepository,
            IClinicRepository clinicRepository,
            IPacientRepository pacientRepository)
        {
            RuleFor(e => e.ConsultationDate).Must(date => date > DateTime.Now)
                .WithMessage("Data de consulta invalida");

            RuleFor(e => e.MedicalSpecialtyId).NotEmpty()
                .MustAsync( async (id,token)=> await medicalSpecialtyRepository.Exists(id))
                .WithMessage("Especialidade médica não encontrada.");

            RuleFor(e => e.PacientId).NotEmpty()
                .MustAsync(async (id, token) => await pacientRepository.Exists(id))
                .WithMessage("Paciente não encontrado.");

            RuleFor(e => e.ClinicId).NotEmpty()
                .MustAsync(async (id, token) => await clinicRepository.Exists(id))
                .WithMessage("Clínica não encontrada.");

            RuleFor(e => e.DoctorId).NotEmpty()
                .MustAsync(async (id, token) => await doctorRepository.Exists(id))
                .WithMessage("Médico não encontrado.");
        }
    }
}
