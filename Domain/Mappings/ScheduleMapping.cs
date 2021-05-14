using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class ScheduleMapping:Profile
    {
        public ScheduleMapping()
        {
            CreateMap<ScheduleInsertViewModel, Schedule>();
        }
    }
}
