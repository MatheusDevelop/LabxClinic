using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IScheduleServices
    {
        public ScheduleViewModel View(ScheduleParams model);
        public Task Insert(ScheduleInsertViewModel model);
        public Task Update(ScheduleInsertViewModel model,Guid id);
        public Task Delete(Guid id);
    }
}
