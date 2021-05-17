using AutoMapper;
using Domain.Services.Interfaces;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;
using Shared.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class CrudService<TEntity,InsertViewModel> where TEntity :Entity
    {
        public readonly IGenericRepository<TEntity> _repository;
        public readonly IMapper _mapper;

        public CrudService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual async Task Insert(InsertViewModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _repository.InsertAsync(entity);
        }
        public virtual async Task Update(InsertViewModel model,Guid id)
        {
            if (!await _repository.Exists(id)) return;
            TEntity entity = _mapper.Map<TEntity>(model);
            entity.SetId(id);
            await _repository.UpdateAsync(entity);
        }
        public virtual async Task Delete(Guid id)
        {
            if (!await _repository.Exists(id)) return;
            await _repository.DeleteAsync(id);
        }
    }
}
