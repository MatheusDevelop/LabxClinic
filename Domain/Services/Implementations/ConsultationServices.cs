using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Entities;
using Shared.Domain.Services;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class ConsultationServices : BaseService, IConsultationServices
    {
        private readonly IMapper _mapper;
        private readonly IConsultationRepository _repository;
       
        public ConsultationServices(
            IMapper mapper,
            IConsultationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public List<ConsultationViewModel> List(ConsultationParams model, FilterViewModel filter)
        {
            IQueryable<Consultation> query = _repository.GetQuery();

            if (model.DoctorId != Guid.Empty)
                query = query.Where(e => e.DoctorId.Equals(model.DoctorId));

            if (model.PacientId != Guid.Empty)
                query = query.Where(e => e.PacientId.Equals(model.PacientId));

            if (!String.IsNullOrEmpty(model.ConsultationName))
                query = query.Where(e => e.ConsultationName.Contains(model.ConsultationName));

            if (model.ConsultationDate != DateTime.MinValue)
                query = query.Where(e => e.ConsultationDate.Date == model.ConsultationDate);

            Expression<Func<Consultation, object>> orderBy = e => e.ConsultationName;

            //if (filter.OrderColumn == "pacient_name")
            //    orderBy = e => e.Pacient.Name;

            List<Consultation> list = _repository.GetList(query, filter,orderBy);

            return GetViewModel(list);

        }
        
        public async Task Insert(ConsultationInsertViewModel model)
        {
            Consultation entity = _mapper.Map<Consultation>(model);
            await _repository.InsertAsync(entity);
        }
        public async Task Delete(Guid id)
        {
            if (await _repository.Exists(id))
                await _repository.DeleteAsync(id);
        }
        public async Task Update(ConsultationInsertViewModel model, Guid id)
        {
            var entity = _mapper.Map<Consultation>(model);
            entity.SetId(id);
            await _repository.UpdateAsync(entity);
        }
        public List<ConsultationViewModel> GetViewModel(List<Consultation> entities)
        {
            var models = new List<ConsultationViewModel>();
            foreach (var entity in entities)
            {
                models.Add(_mapper.Map<ConsultationViewModel>(entity));
            }
            return models;
        }
    }
}
