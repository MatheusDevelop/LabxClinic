using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Services.Interfaces;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IConsultationServices:IBaseService
    {
        public List<ConsultationListViewModel> List(ConsultationParams model, FilterViewModel filter);
        public Task Insert(ConsultationInsertViewModel model);
        public Task Update(ConsultationInsertViewModel model, Guid id);
        public Task Delete(Guid id);
    }
}
