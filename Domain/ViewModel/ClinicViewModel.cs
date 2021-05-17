using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class ClinicSelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class ClinicParams 
    {
        public Guid Id { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
    }
    public class ClinicInsertViewModel 
    {
        public string Name { get; set; }
        public string PicUrl { get; set; }
    }
    public class ClinicViewModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public AddressViewModel Address { get; set; } = new AddressViewModel();
    }
}
