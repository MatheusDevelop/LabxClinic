using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SurgeryRepository : GenericRepository<Surgery>, ISurgeryRepository
    {
        public SurgeryRepository(LabxContext con) : base(con)
        {
        }
    }
}
