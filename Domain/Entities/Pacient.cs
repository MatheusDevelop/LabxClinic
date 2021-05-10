using Shared.Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pacient:Entity
    {
        public ICollection<Consultation> Consultations { get; private set; }
    }
}