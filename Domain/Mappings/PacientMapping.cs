using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class PacientMapping:Profile
    {
        public PacientMapping()
        {
            CreateMap<PacientInsertViewModel, Pacient>().ForMember(s => s.Allergies, opt=> opt.Ignore())
                .ForMember(s => s.Surgeries, opt => opt.Ignore());
            CreateMap<Pacient, PacientViewModel>().ReverseMap();
        }
    }
}
