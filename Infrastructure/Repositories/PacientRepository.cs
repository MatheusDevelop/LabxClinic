using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PacientRepository : GenericRepository<Pacient>, IPacientRepository
    {
        public PacientRepository(LabxContext con) : base(con)
        {
        }
    }
}
