using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.Services.Interfaces;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IMedicalSpecialtyServices:ICrudServices<MedicalSpecialty,MedicalSpecialtyInsertViewModel>
    {
        public List<MedicalSpecialtySelectViewModel> Select(FilterViewModel filter);
        public List<MedicalSpecialtySelectViewModel> GetSelectViewModel(List<MedicalSpecialty> entities);
    }
}
