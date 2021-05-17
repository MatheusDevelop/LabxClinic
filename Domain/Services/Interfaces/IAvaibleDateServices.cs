using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IAvaibleDateServices:ICrudServices<AvailableDate,AvaibleDateInsertViewModel>
    {
        public List<AvailableDateViewModel> List(AvailableDateParams model, FilterViewModel filter);
    }
}
