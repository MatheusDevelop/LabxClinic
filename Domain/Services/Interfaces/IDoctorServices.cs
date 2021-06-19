using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.Services.Interfaces;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IDoctorServices:ICrudServices<Doctor,DoctorInsertViewModel>
    {
        public List<DoctorSelectViewModel> Select(FilterViewModel model);
        public List<DoctorViewModel> List(DoctorParams model,FilterViewModel filter);
        DoctorSelectViewModel GetSelectViewModel(Doctor entity);
    }
}
