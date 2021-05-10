using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.ViewModels;
using Shared.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> where T : class
    {
        private readonly LabxContext _con;
        internal DbSet<T> dbEntity;

        public GenericRepository(LabxContext con)
        {
            _con = con;
            dbEntity = _con.Set<T>();

        }
        public List<T> GetList(IQueryable<T> query, FilterViewModel filter, Expression<Func<T, object>> orderBy = null)
        {
            filter.TotalInDatabase = query.Count();

            if (orderBy != null)
            {
                if (filter.Order == "asc")
                    query = query.OrderBy(orderBy);
                if (filter.Order == "desc")
                    query = query.OrderByDescending(orderBy);
            }

            query = Pagination<T>.Get(filter, query);
            return query.ToList();
        }
        public async Task<bool> Exists(Guid id)
        {
            return await Find(id) != null;
        }
        public IQueryable<T> GetQuery()
        {
            return dbEntity.AsNoTracking().AsQueryable();
        }
        public async Task DeleteAsync(T entity)
        {
            dbEntity.Remove(entity);
            await _con.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await Find(id);
            dbEntity.Remove(entity);
            await _con.SaveChangesAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await dbEntity.AddAsync(entity);
            await _con.SaveChangesAsync();
        }

        public async Task<T> Find(Guid id)
        {
            var entity = await dbEntity.FindAsync(id);
            if (entity != null)
                _con.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            dbEntity.Update(entity);
            await _con.SaveChangesAsync();
        }
    }
}
