﻿using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Implementations
{
    public class DoctorClinicMedicalSpecialtyServices : CrudService<DoctorClinicMedicalSpecialty, DoctorClinicMedicalSpecialtyInsertViewModel>,IDoctorClinicMedicalSpecialtyServices
    {
        public DoctorClinicMedicalSpecialtyServices(IDoctorClinicMedicalSpecialtyRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
