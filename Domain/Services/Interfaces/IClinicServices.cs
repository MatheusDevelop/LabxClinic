using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IClinicServices:ICrudServices<Clinic,ClinicInsertViewModel>
    {
        public List<ClinicSelectViewModel> Select(FilterViewModel filter);
        public List<ClinicViewModel> List(ClinicParams model, FilterViewModel filter);
        public List<ClinicViewModel> GetViewModel(List<Clinic> entities);
        public ClinicViewModel GetViewModel(Clinic entities);

    }
}
