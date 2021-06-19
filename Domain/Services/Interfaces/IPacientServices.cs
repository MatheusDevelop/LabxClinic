using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.Services.Interfaces;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IPacientServices:ICrudServices<Pacient,PacientInsertViewModel>
    {
        PacientSelectViewModel GetSelectViewModel(Pacient entity);
        List<PacientSelectViewModel> List(PacientParams model, FilterViewModel filter);
        public PacientViewModel View(Guid pacientId);
    }
}
