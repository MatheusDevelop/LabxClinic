using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class AvaliationRepository : GenericRepository<Avaliation>, IAvaliationRepository
    {
        public AvaliationRepository(LabxContext con) : base(con)
        {
        }
    }
}
