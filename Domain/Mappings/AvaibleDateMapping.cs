using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class AvaibleDateMapping:Profile
    {
        public AvaibleDateMapping()
        {
            CreateMap<AvaibleDateInsertViewModel, AvailableDate>();
            CreateMap<AvailableDate, AvailableDateViewModel>()
                .ForMember(e=> e.Hour,op=> op.MapFrom(x=> x.Date.Hour))
                .ForMember(e=> e.Minutes,op=> op.MapFrom(x=> x.Date.Minute))
            ;

        }
    }
}
