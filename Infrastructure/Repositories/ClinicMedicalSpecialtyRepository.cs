using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ClinicMedicalSpecialtyRepository : GenericRepository<ClinicMedicalSpecialty>, IClinicMedicalSpecialtyRepository
    {
        public ClinicMedicalSpecialtyRepository(LabxContext con) : base(con)
        {
        }
    }
}
