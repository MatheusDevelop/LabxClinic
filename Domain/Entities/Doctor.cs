using Shared.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Doctor:Entity
    {
        public ICollection<Consultation> Consultations { get; private set; }
    }
}