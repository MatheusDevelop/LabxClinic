using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Implementations
{
    public class AddressServices:IAddressServices
    {
        private readonly IMapper _mapper;

        public AddressServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AddressViewModel GetViewModel(Address entity) 
        {
            return _mapper.Map<AddressViewModel>(entity);
        }
    }
}
