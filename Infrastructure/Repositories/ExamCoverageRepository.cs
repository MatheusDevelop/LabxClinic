using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ExamCoverageRepository : GenericRepository<ExamCoverage>, IExamCoverageRepository
    {
        public ExamCoverageRepository(LabxContext con) : base(con)
        {
        }
    }
}
