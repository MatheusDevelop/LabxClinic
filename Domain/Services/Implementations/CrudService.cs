using AutoMapper;
using Domain.Services.Interfaces;
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
            TEntity entity = ConvertToEntity(model);
            await _repository.InsertAsync(entity);
        }
        public virtual async Task Insert(TEntity entity)
        {
            await _repository.InsertAsync(entity);
        }
        public virtual async Task Insert(List<TEntity> entity)
        {
            await _repository.InsertRangeAsync(entity);
        }
        public virtual async Task Insert(List<InsertViewModel> model)
        {
            var entity = ConvertToEntity(model);
            await _repository.InsertRangeAsync(entity);
        }
        public virtual async Task<TEntity> InsertAndReturnEntity(InsertViewModel model)
        {
            var entity = ConvertToEntity(model);
            await _repository.InsertAsync(entity);
            return entity;
        }
        public virtual async Task Delete(List<Guid> id)
        {
            await _repository.DeleteRangeAsync(id);
        }
        public virtual async Task Delete(List<TEntity> entities)
        {
            await _repository.DeleteRangeAsync(entities);
        }

        private TEntity ConvertToEntity(InsertViewModel model)
        {
            return _mapper.Map<TEntity>(model);
        }
        private List<TEntity> ConvertToEntity(List<InsertViewModel> model)
        {
            var result = new List<TEntity>();
            foreach (var item in model)
            {
                result.Add(ConvertToEntity(item));
            }
            return result;
        }

        public virtual async Task Update(InsertViewModel model,Guid id)
        {
            if (!await _repository.Exists(id)) return;
            TEntity entity = _mapper.Map<TEntity>(model);
            entity.SetId(id);
            entity.UpdateEntity();
            await _repository.UpdateAsync(entity);
        }
        public virtual async Task<TEntity> UpdateAndReturnEntity(InsertViewModel model, Guid id)
        {
            if (!await _repository.Exists(id)) return null;
            TEntity entity = _mapper.Map<TEntity>(model);
            entity.SetId(id);
            await _repository.UpdateAsync(entity);
            return entity;
        }
        public virtual async Task Delete(Guid id)
        {
            if (!await _repository.Exists(id)) return;
            await _repository.DeleteAsync(id);
        }
    }
}
