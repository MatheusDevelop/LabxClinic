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
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class AvaliationServices : CrudService<Avaliation, AvaliationInsertViewModel>, IAvaliationServices
    {
        public AvaliationServices(IAvaliationRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public override Task Insert(AvaliationInsertViewModel model)
        {
            model.Note = model.Note >= 5 ? 5 : model.Note;  
            return base.Insert(model);
        }
        public (List<AvaliationListViewModel>content , string average  )List(AvaliationParams model, FilterViewModel filter)
        {
            try
            {
                var query = _repository.GetQuery();
                if (model.DoctorId != Guid.Empty)
                    query = query.Where(e => e.DoctorId.Equals(model.DoctorId)).OrderBy(e => e.CreationDate);
                string average = String.Format("{0:0.0}",query.ToList().Average(e=> e.Note));

                Expression<Func<Avaliation, Object>> orderBy = e => e.CreationDate;
                var list = _repository.GetList(query, filter, orderBy);
                return (content:list.Select(e => _mapper.Map<AvaliationListViewModel>(e)).ToList(),average);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
