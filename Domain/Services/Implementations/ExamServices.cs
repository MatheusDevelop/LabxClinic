using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Repositories;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Services.Implementations
{
    public class ExamServices : CrudService<Exam, ExamInsertViewModel>, IExamServices
    {
        public ExamServices(IExamRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public (List<ExamViewModel>, int totalPendencyInDatabase, int totalAvailableInDatabase) List(ExamParams model ,FilterViewModel filter)
            {
            try
            {
                var query = _repository.GetQuery().Include(e=> e.Doctor).Include(e=> e.Pacient).AsQueryable();
                

                if (model.DoctorId != Guid.Empty)
                    query = query.Where(e => e.DoctorId.Equals(model.DoctorId));
                if (model.PacientId != Guid.Empty)
                    query = query.Where(e => e.PacientId.Equals(model.PacientId));

                var totalPendencyInDatabase = query.Where(e => e.Pendency).Count();
                var totalAvailableInDatabase = query.Where(e => !e.Pendency).Count();

                if (model.UnvailableExams != null && (bool)model.UnvailableExams)
                    query = query.Where(e => e.Pendency == true);
                if (model.UnvailableExams != null && !(bool)model.UnvailableExams)
                    query = query.Where(e => e.Pendency == false);
                if (filter.Quicksearch != null)
                    query = query.Where(e => e.Name.Contains(filter.Quicksearch));

                Expression<Func<Exam, object>> orderBy = e => e.UpdateDate;

                if (filter.OrderColumn == "doctorName") orderBy = e => e.Doctor.Name;
                

                var list = _repository.GetList(query, filter, orderBy);
                var content = ConvertToViewModel(list);
               
                return (content,totalPendencyInDatabase,totalAvailableInDatabase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ExamViewModel> ConvertToViewModel(List<Exam> list)
        {
            return list.Select(e => _mapper.Map<ExamViewModel>(e)).ToList();
        }
    }
}
