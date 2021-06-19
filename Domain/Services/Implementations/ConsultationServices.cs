using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IClinicServices _clinicServices;
        private readonly IDoctorServices _doctorServices;
        private readonly IPacientServices _pacientServices;
        public ConsultationServices(
            IMapper mapper,
            IConsultationRepository repository, IClinicServices clinicServices, IDoctorServices doctorServices, IPacientServices pacientServices)
        {
            _mapper = mapper;
            _repository = repository;
            _clinicServices = clinicServices;
            _doctorServices = doctorServices;
            _pacientServices = pacientServices;
        }


        public List<ConsultationListViewModel> List(ConsultationParams model, FilterViewModel filter)
        {
            IQueryable<Consultation> query = _repository.GetQuery().Include(e => e.Clinic).ThenInclude(e=> e.ClinicAddress).Include(e => e.Pacient).Include(e => e.Doctor);

            if (!String.IsNullOrEmpty(filter.Quicksearch))
                query = query.Where(e => e.ConsultationName.Contains(filter.Quicksearch));

            if (model.Id != Guid.Empty)
                query = query.Where(e => e.Id.Equals(model.Id));

            if (model.DoctorId != Guid.Empty)
                query = query.Where(e => e.DoctorId.Equals(model.DoctorId));

            if (model.PacientId != Guid.Empty)
                query = query.Where(e => e.PacientId.Equals(model.PacientId));

            if (!String.IsNullOrEmpty(model.ConsultationName))
                query = query.Where(e => e.ConsultationName.Contains(model.ConsultationName));

            if (model.ConsultationDate != DateTime.MinValue)
                query = query.Where(e => e.ConsultationDate.Date == model.ConsultationDate);

            Expression<Func<Consultation, object>> orderBy = e => e.ConsultationDate;

            List<Consultation> list = _repository.GetList(query, filter, orderBy);

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
        public List<ConsultationListViewModel> GetViewModel(List<Consultation> entities)
        {
            var models = new List<ConsultationListViewModel>();
            foreach (var entity in entities)
            {
                models.Add(GetViewModel(entity));
            }
            return models;
        }

        private ConsultationListViewModel GetViewModel(Consultation entity)
        {
            ConsultationListViewModel model = _mapper.Map<ConsultationListViewModel>(entity);
            model.Doctor = _doctorServices.GetSelectViewModel(entity.Doctor);
            model.Pacient = _pacientServices.GetSelectViewModel(entity.Pacient);
            model.Clinic = _clinicServices.GetViewModel(entity.Clinic);

            return model;
        }


    }
}
