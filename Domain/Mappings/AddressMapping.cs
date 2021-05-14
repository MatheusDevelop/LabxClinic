using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings
{
    public class AddressMapping:Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, AddressViewModel>();
        }
    }
}
