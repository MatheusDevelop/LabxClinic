using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class AvaibleDateServices:BaseService,IAvaibleDateServices
    {
        private readonly IAvaibleDateRepository _repository;
        private readonly IMapper _mapper;
        public AvaibleDateServices(IAvaibleDateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Insert(AvaibleDateInsertViewModel model)
        {
            var entity = _mapper.Map<AvaibleDate>(model);            
            await _repository.InsertAsync(entity);
        }
    }
}
