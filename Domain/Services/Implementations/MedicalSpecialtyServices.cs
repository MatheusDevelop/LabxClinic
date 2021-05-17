using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Services;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Services.Implementations
{
    public class MedicalSpecialtyServices : CrudService<MedicalSpecialty,MedicalSpecialtyInsertViewModel>,IMedicalSpecialtyServices
    {
        private readonly IMedicalSpecialtyRepository _repository;
        private readonly IMapper _mapper;

        public MedicalSpecialtyServices(IMedicalSpecialtyRepository repository, IMapper mapper):base(repository,mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<MedicalSpecialtySelectViewModel> Select(FilterViewModel filter) 
        {
            try 
            {
                IQueryable<MedicalSpecialty> query = _repository.GetQuery();

                if (!string.IsNullOrEmpty(filter.Quicksearch))
                    query = query.Where(e => e.Name.Contains(filter.Quicksearch));

                Expression<Func<MedicalSpecialty, object>> orderBy = e => e.Name;
                List<MedicalSpecialty> list = _repository.GetList(query, filter,orderBy);
                return GetSelectViewModel(list);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<MedicalSpecialtySelectViewModel> GetSelectViewModel(List<MedicalSpecialty> entities)
        {
            var models = new List<MedicalSpecialtySelectViewModel>();
            foreach (var entity in entities)
            {
                models.Add(_mapper.Map<MedicalSpecialtySelectViewModel>(entity));
            }
            return models;
        }
    }
}
