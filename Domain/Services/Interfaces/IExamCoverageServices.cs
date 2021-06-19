using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IExamCoverageServices : ICrudServices<ExamCoverage, ExamCoverageInsertViewModel>
    {
        List<ExamCoverageListViewModel> List(ExamCoverageParams model, FilterViewModel filter);
    }
}
