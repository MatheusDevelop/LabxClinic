using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class PacientSelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
    }
    public class PacientListViewModel:PacientSelectViewModel {
    }

    public class PacientParams {
        public Guid DoctorId { get; set; }
    }

    public class PacientViewModel :PersonViewModel
    {
        
        public Guid InsuranceId { get; set; }
        public string BloodType { get; set; }
        public bool AlreadyHadAvc { get; set; }
        public bool AlreadyFainted { get; set; }
        public bool HaveWalkingDifficulty { get; set; }
        public List<AllergySelectViewModel> Allergies { get; set; }
        public List<SurgerySelectViewModel> Surgeries { get; set; }
    }

    public class PacientInsertViewModel 
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        
        public string BloodType { get; set; }
        public bool AlreadyHadAvc { get; set; }
        public bool AlreadyFainted { get; set; }
        public bool HaveWalkingDifficulty { get; set; }
        public Guid InsuranceId { get; set; }
        public Guid UserId { get; set; }
    }
}
