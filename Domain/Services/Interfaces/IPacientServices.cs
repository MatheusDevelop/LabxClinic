using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IPacientServices:ICrudServices<Pacient,PacientInsertViewModel>
    {
        public PacientViewModel View(Guid pacientId);
    }
}
