using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class SurgeryMapping:Profile
    {
        public SurgeryMapping()
        {
            CreateMap<SurgeryInsertViewModel, Surgery>();
            CreateMap<Surgery, SurgerySelectViewModel>();

        }
    }
}
