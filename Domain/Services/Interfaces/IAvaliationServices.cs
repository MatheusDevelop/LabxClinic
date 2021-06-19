using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IAvaliationServices : ICrudServices<Avaliation, AvaliationInsertViewModel>
    {
        (List<AvaliationListViewModel> content, string average) List(AvaliationParams model, FilterViewModel filter);
    }
}
