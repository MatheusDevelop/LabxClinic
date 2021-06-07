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
    public class AllergyServices : CrudService<Allergy, AllergyInsertViewModel>, IAllergyServices
    {
        public AllergyServices(IAllergyRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public List<AllergySelectViewModel> GetWithPacientId(Guid id)
        {
            try
            {
                var query = _repository.GetQuery().Where(e => e.PacientId.Equals(id)).OrderBy(e=> e.CreationDate);
                return query.Select(e => _mapper.Map<AllergySelectViewModel>(e)).ToList();

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
