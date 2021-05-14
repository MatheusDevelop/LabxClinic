using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Services;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Services.Implementations
{
    public class ClinicServices : BaseService,IClinicServices
    {
        private readonly IClinicRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAddressServices _addressServices;

        public ClinicServices(IClinicRepository repository, IMapper mapper, IAddressServices addressServices)
        {
            _repository = repository;
            _mapper = mapper;
            _addressServices = addressServices;
        }
        public List<ClinicViewModel> List(ClinicParams model,FilterViewModel filter) 
        {
            try
            {
                IQueryable<Clinic> query = _repository.GetQuery().Include(e=> e.ClinicAddress);
                if (model.Id != Guid.Empty)
                    query = query.Where(e => e.Id.Equals(model.Id));
                if (model.MedicalSpecialtyId != Guid.Empty)
                    query = query.Where(e => e.ClinicMedicalSpecialties.Any(e=> e.ClinicId.Equals(model.Id)));

                query = QuicksearchFilter(filter, query);

                Expression<Func<Clinic, object>> orderBy = e => e.Name;
                List<Clinic> list = _repository.GetList(query, filter, orderBy);
                return GetViewModel(list);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private List<ClinicViewModel> GetViewModel(List<Clinic> entities)
        {
            var models = new List<ClinicViewModel>();
            foreach (var entity in entities)
            {
                ClinicViewModel entityMapped = _mapper.Map<ClinicViewModel>(entity);
                entityMapped.Address = _addressServices.GetViewModel(entity.ClinicAddress);
                models.Add(entityMapped);
            }
            return models;
        }

        public List<ClinicSelectViewModel> Select(FilterViewModel filter) 
        {
            try
            {
                IQueryable<Clinic> query = _repository.GetQuery();

                query = QuicksearchFilter(filter, query);

                Expression<Func<Clinic, object>> orderBy = e => e.Name;
                List<Clinic> list = _repository.GetList(query, filter, orderBy);
                return GetSelectViewModel(list);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static IQueryable<Clinic> QuicksearchFilter(FilterViewModel filter, IQueryable<Clinic> query)
        {
            if (!string.IsNullOrEmpty(filter.Quicksearch))
                query = query.Where(e => 
                e.Name.Contains(filter.Quicksearch)
                || e.ClinicAddress.City.Contains(filter.Quicksearch)
                || e.ClinicAddress.Street.Contains(filter.Quicksearch)
                );
            return query;
        }

        public List<ClinicSelectViewModel> GetSelectViewModel(List<Clinic> entities)
        {
            var models = new List<ClinicSelectViewModel>();
            foreach (var entity in entities)
            {
                models.Add(_mapper.Map<ClinicSelectViewModel>(entity));
            }
            return models;
        }
    }
}
