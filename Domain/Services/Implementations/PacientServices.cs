using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;
using Shared.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class PacientServices : CrudService<Pacient, PacientInsertViewModel>, IPacientServices
    {
        private readonly IAllergyServices _allergyServices;
        private readonly ISurgeryServices _surgeryServices;

        public PacientServices(IPacientRepository repository, IMapper mapper, IAllergyServices allergyServices, ISurgeryServices surgeryServices) : base(repository, mapper)
        {
            _allergyServices = allergyServices;
            _surgeryServices = surgeryServices;
        }
        public PacientViewModel View(Guid pacientId)
        {
            try
            {
                var pacient = _repository.GetQuery().FirstOrDefault(e => e.Id.Equals(pacientId));
                if (pacient == null) return null;
                var model = _mapper.Map<PacientViewModel>(pacient);
                model.Allergies = _allergyServices.GetWithPacientId(pacient.Id);
                model.Surgeries = _surgeryServices.GetWithPacientId(pacient.Id);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
