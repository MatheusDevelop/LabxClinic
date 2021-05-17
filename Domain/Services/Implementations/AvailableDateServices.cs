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
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class AvailableDateServices : CrudService<AvailableDate, AvaibleDateInsertViewModel>, IAvaibleDateServices
    {
        public AvailableDateServices(IAvaibleDateRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
        public List<AvailableDateViewModel> List(AvailableDateParams model,FilterViewModel filter)
        {
            try
            {
                var query = _repository.GetQuery();
                if (model.ScheduleId != Guid.Empty)
                    query = query.Where(e => e.ScheduleId.Equals(model.ScheduleId));
                if (model.ClinicId != Guid.Empty)
                    query = query.Where(e => e.Schedule.ClinicId.Equals(model.ClinicId));
                if (model.DoctorId != Guid.Empty)
                    query = query.Where(e => e.DoctorId.Equals(model.DoctorId));
                if (model.Day != 0)
                    query = query.Where(e => e.Date.Day.Equals(model.Day));

                var list = _repository.GetList(query, filter);
                return GetViewModel(list);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private List<AvailableDateViewModel> GetViewModel(List<AvailableDate> entities)
        {
            var models = new List<AvailableDateViewModel>();
            foreach (var entity in entities)
            {
                models.Add(_mapper.Map<AvailableDateViewModel>(entity));
            }
            return models;
        }
    }
}
