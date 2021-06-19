using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class DoctorSelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class DoctorViewModel :PersonViewModel
    {
        public string Crm { get; set; }
        public List<MedicalSpecialtySelectViewModel> MedicalSpecialties { get; set; }
    }
    
    public class DoctorParams 
    {
        
        public string Name { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
        public Guid ClinicId { get; set; }
        public DateTime AvailableDate { get; set; }
        public Guid? DoctorId { get; set; }
    }
    public class DoctorInsertViewModel 
    {
        public string Crm { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }

    }

}
