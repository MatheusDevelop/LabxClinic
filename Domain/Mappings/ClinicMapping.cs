using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class ClinicMapping:Profile
    {
        public ClinicMapping()
        {
            CreateMap<Clinic, ClinicSelectViewModel>();
            CreateMap<Clinic, ClinicViewModel>();
        }
    }
}
