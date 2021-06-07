using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class PacientSelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class PacientViewModel 
    {
        public string Document { get; private set; }
        public string Name { get; private set; }
        public string ProfilePicUrl { get; private set; }
        public string Description { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Guid Id { get; set; }
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
        public Guid UserId { get; set; }
    }
}
