using Shared.Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Doctor:Entity
    {
        public ICollection<AvaibleDate> AvaibleDates { get; private set; }
        public ICollection<Consultation> Consultations { get; private set; }
    }
}