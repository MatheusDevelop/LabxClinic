using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class MedicalSpecialtySelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }

    }
    public class MedicalSpecialtyInsertViewModel 
    {
        public string Name { get; set; }
        public string PicUrl { get; set; }
    }
}
