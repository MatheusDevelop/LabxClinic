using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class AllergySelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class AllergyInsertViewModel
    {
        public Guid PacientId { get; set; }
        public string Name { get; set; }
    }
}
