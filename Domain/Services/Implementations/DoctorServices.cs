using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;
using Shared.Domain.Services;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services.Implementations
{
    public class DoctorServices : CrudService<Doctor, DoctorInsertViewModel>, IDoctorServices
    {
        public DoctorServices(IDoctorRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public List<DoctorViewModel> List(DoctorParams model,FilterViewModel filter) 
         {
            try
            {
                IQueryable<Doctor> query = _repository.GetQuery();
                if (model.DoctorId != null)
                    query = query.Where(e => e.Id.Equals((Guid)model.DoctorId));
                if (model.Name != null)
                    query = query.Where(e => e.Name.Contains(model.Name));
                if (model.AvailableDate != DateTime.MinValue)
                    query = query.Where(e => e.AvaibleDates.Any(e => 
                    e.Date.Date.Equals(model.AvailableDate.Date)
                    && e.Date.Month.Equals(model.AvailableDate.Month)
                    && e.Date.Year.Equals(model.AvailableDate.Year)
                    && e.Date.Hour.Equals(model.AvailableDate.Hour)
                    && e.Date.Minute.Equals(model.AvailableDate.Minute)
                    ));
                if (model.ClinicId != Guid.Empty)
                    query = query.Where(e => e.ClinicId.Equals(model.ClinicId));
                if (model.MedicalSpecialtyId != Guid.Empty)
                    query = query.Where(e => e.DoctorClinicMedicalSpecialties.Any(e=> e.ClinicMedicalSpecialty.MedicalSpecialtyId.Equals(model.MedicalSpecialtyId)));
                query = QuicksearchFilter(filter, query);
                return GetViewModel(_repository.GetList(query, filter));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static IQueryable<Doctor> QuicksearchFilter(FilterViewModel filter, IQueryable<Doctor> query)
        {
            if (!String.IsNullOrEmpty(filter.Quicksearch))
                query = query.Where(e => e.Name.Contains(filter.Quicksearch));
            return query;
        }

        private List<DoctorViewModel> GetViewModel(List<Doctor> entities)
        {
            var models = new List<DoctorViewModel>();
            foreach (var entity in entities)
            {
                models.Add(_mapper.Map<DoctorViewModel>(entity));
            }
            return models;
        }

        public List<DoctorSelectViewModel> Select(FilterViewModel filter)
        {
            try
            {
                IQueryable<Doctor> query = _repository.GetQuery();
                query = QuicksearchFilter(filter, query);
                return GetSelectViewModel(_repository.GetList(query, filter));
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<DoctorSelectViewModel> GetSelectViewModel(List<Doctor> entities)
        {
            var models = new List<DoctorSelectViewModel>();
            foreach (var entity in entities)
            {
                models.Add(_mapper.Map<DoctorSelectViewModel>(entity));
            }
            return models;
        }
    }
}
