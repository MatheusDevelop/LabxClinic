using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface ICrudServices<TEntity, InsertViewModel> where TEntity : Entity
    {
        public Task Insert(InsertViewModel model);
        public Task Update(InsertViewModel model, Guid id);
        public Task Delete(Guid id);

    }
}
