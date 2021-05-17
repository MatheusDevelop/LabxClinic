using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class ClinicMedicalSpecialtyMapping:Profile
    {
        public ClinicMedicalSpecialtyMapping()
        {
            CreateMap<ClinicMedicalSpecialtyInsertViewModel, ClinicMedicalSpecialty>();
        }
    }
}
