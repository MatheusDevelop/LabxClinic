using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services.Implementations
{
    public class InsuranceServices : CrudService<Insurance, InsuranceInsertViewModel>, IInsuranceServices
    {
        public InsuranceServices(IInsuranceRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public InsuranceViewModel GetWithPacientId(Guid pacientId) 
        {
            return _mapper.Map<InsuranceViewModel>(_repository.GetQuery().FirstOrDefault(e => e.Pacients.Any(x => x.Id.Equals(pacientId))));
        }
        
    }
}
