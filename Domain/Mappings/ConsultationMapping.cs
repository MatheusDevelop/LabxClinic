using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings.ConsultationMaps
{
    public class ConsultationMapping:Profile
    {
        public ConsultationMapping()
        {
            CreateMap<ConsultationInsertViewModel, Consultation>();
            CreateMap<ConsultationViewModel, Consultation>();
        }
    }
}
