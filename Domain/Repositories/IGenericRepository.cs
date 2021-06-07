using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shared.Domain.Repositories
{
    public interface IGenericRepository<T> where T:class
    {

        public List<T> GetList(IQueryable<T> query, FilterViewModel filter, Expression<Func<T, object>> orderBy = null);
        public IQueryable<T> GetQuery();
        public Task<T> Find(Guid id);
        public Task InsertAsync(T entity);
        public Task InsertRangeAsync(List<T> entity);
        public Task DeleteRangeAsync(List<T> entity);
        public Task UpdateAsync(T entity);
        public Task<bool> Exists(Guid id);
        public Task DeleteAsync(T entity);
        public Task DeleteAsync(Guid id);
        public Task DeleteRangeAsync(List<Guid> id);


    }
}
