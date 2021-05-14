using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IAddressServices
    {
        public AddressViewModel GetViewModel(Address entity);
    }
}
