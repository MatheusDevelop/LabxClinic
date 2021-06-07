using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class SurgerySelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class SurgeryInsertViewModel
    {
        public Guid PacientId { get; set; }
        public string Name { get; set; }
    }
}
