using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IExamServices : ICrudServices<Exam, ExamInsertViewModel>
    {
        public (List<ExamViewModel>, int totalPendencyInDatabase, int totalAvailableInDatabase) List(ExamParams model, FilterViewModel filter);
    }
}
