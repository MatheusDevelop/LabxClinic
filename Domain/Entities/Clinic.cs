using Shared.Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Clinic:Entity
    {
        public ICollection<Consultation> Consultations { get; private set; }

    }
}