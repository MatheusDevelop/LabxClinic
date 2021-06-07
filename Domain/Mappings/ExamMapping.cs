using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class ExamMapping : Profile
    {
        public ExamMapping()
        {
            CreateMap<ExamInsertViewModel, Exam>();
            CreateMap<Exam, ExamViewModel>()
                .ForMember(e => e.DoctorName, opt => opt.MapFrom(x => x.Doctor.Name))
                .ForMember(e => e.PacientName, opt => opt.MapFrom(x => x.Pacient.Name))
                .ForMember(e => e.DoctorPicUrl, opt => opt.MapFrom(x => x.Doctor.ProfilePicUrl))
                .ForMember(e => e.PacientPicUrl, opt => opt.MapFrom(x => x.Pacient.ProfilePicUrl))
                ;


        }
    }
}
