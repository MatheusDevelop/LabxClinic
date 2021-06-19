using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class InsuranceMapping:Profile
    {
        public InsuranceMapping()
        {
            CreateMap<InsuranceInsertViewModel, Insurance>();
            CreateMap<Insurance,InsuranceViewModel>();

        }
    }
}
