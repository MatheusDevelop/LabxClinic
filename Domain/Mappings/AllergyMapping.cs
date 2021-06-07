using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class AllergyMapping:Profile
    {
        public AllergyMapping()
        {
            CreateMap<AllergyInsertViewModel, Allergy>();
            CreateMap<Allergy, AllergySelectViewModel>();

        }
    }
}
