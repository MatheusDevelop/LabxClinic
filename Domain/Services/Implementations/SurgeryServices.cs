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
    public class SurgeryServices : CrudService<Surgery, SurgeryInsertViewModel>, ISurgeryServices
    {
        public SurgeryServices(ISurgeryRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public List<SurgerySelectViewModel> GetWithPacientId(Guid id)
        {
            try
            {
                var query = _repository.GetQuery().Where(e => e.PacientId.Equals(id));
                return query.Select(e => _mapper.Map<SurgerySelectViewModel>(e)).ToList();

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
