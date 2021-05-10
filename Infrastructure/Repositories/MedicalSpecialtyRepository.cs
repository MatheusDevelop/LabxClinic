using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MedicalSpecialtyRepository : GenericRepository<MedicalSpecialty>, IMedicalSpecialtyRepository
    {
        public MedicalSpecialtyRepository(LabxContext con) : base(con)
        {
        }
    }
}
