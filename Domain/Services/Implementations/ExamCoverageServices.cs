using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Repositories;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Services.Implementations
{
    public class ExamCoverageServices : CrudService<ExamCoverage, ExamCoverageInsertViewModel>, IExamCoverageServices
    {
        public ExamCoverageServices(IExamCoverageRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public List<ExamCoverageListViewModel> List(ExamCoverageParams model, FilterViewModel filter)
        {
            try
            {
                var query = _repository.GetQuery();
                if (model.PacientId != Guid.Empty)
                    query = query.Where(e => e.Insurance.Pacients.Any(x => x.Id.Equals(model.PacientId)));
                if (!String.IsNullOrEmpty(filter.Quicksearch))
                    query = query.Where(e => e.Name.Contains(filter.Quicksearch));

                Expression<Func<ExamCoverage, object>> orderBy = e => e.Name;
                var list = _repository.GetList(query, filter, orderBy);

                return list.Select(e => _mapper.Map<ExamCoverageListViewModel>(e)).ToList();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
