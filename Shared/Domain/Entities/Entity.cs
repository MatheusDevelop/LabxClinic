using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; private set; } = DateTime.UtcNow;
        public bool Deleted { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            Deleted = false;
        }
        public void Delete() { Deleted = true; }
        public void UpdateEntity()
        {
            UpdateDate = DateTime.UtcNow;
        }
        public void SetId(Guid id) 
        {
            Id = id;
        }
    }
}
