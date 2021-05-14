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
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class ScheduleServices:BaseService,IScheduleServices
    {
        private readonly IScheduleRepository _repository;
        private readonly IMapper _mapper;
        public ScheduleServices(IScheduleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public ScheduleViewModel View(ScheduleParams model)
        {
            var query = _repository.GetQuery().Include(e=> e.AvaibleDates).AsQueryable();
            if (model.ClinicId != Guid.Empty)
                query = query.Where(e => e.ClinicId.Equals(model.ClinicId));
            if (model.MedicalSpecialtyId != Guid.Empty)
                query = query.Where(e => e.MedicalSpecialtyId.Equals(model.MedicalSpecialtyId));
            if (model.Month != null)
                query = query.Where(e => e.AvaibleDates.Any(e => e.Date.Month.Equals(model.Month)));

            var list = _repository.GetList(query,new FilterViewModel());
            if (list.Count == 0) return null;

            var avaibleDays = new List<DateTime>();
            foreach (var item in list[0].AvaibleDates)
            {
                avaibleDays.Add(item.Date);
            }
            return new ScheduleViewModel(list[0].Id,avaibleDays);

        }
        public async Task Insert(ScheduleInsertViewModel model) 
        {
            var entity = _mapper.Map<Schedule>(model);
            await _repository.InsertAsync(entity);
        }
        public async Task Update(ScheduleInsertViewModel model,Guid id)
        {
            if (! await _repository.Exists(id)) return;

            var entity = _mapper.Map<Schedule>(model);
            entity.SetId(id);
            await _repository.UpdateAsync(entity);
        }
        public async Task Delete(Guid id)
        {
            if (!await _repository.Exists(id)) return;
            await _repository.DeleteAsync(id);
        }
    }
}
