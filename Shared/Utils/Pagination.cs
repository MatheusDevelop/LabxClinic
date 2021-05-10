using Shared.Domain.ViewModels;
using System;
using System.Linq;

namespace Shared.Infrastructure.Utils
{
    public static class Pagination<T> where T : class
    {
        public static IQueryable<T> Get(FilterViewModel filter, IQueryable<T> query)
        {
            int pageCount = ((query.Count() - 1) / filter.ItemsByPage) + 1;

            filter.NumberOfPage = Math.Min(filter.NumberOfPage == 0 ? 1 : filter.NumberOfPage, pageCount);

            query = query.Skip((filter.NumberOfPage - 1) * filter.ItemsByPage).Take(filter.ItemsByPage);
            return query;
        }
    }
}
