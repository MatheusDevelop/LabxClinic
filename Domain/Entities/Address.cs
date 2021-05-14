using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class Address:Entity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
    }
}
