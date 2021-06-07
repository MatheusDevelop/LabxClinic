using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class ConsultationInsertViewModel 
    {
        public Guid DoctorId { get; set; }
        public Guid PacientId { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
        public Guid ClinicId { get; set; }
        public DateTime ConsultationDate { get; set; }
        public string ConsultationName { get; set; }

    }
    public class ConsultationViewModel 
    {
        public DoctorSelectViewModel Doctor { get; set; }
        public PacientSelectViewModel Pacient { get; set; }
        public DateTime ConsultationDate { get; set; }
        public string ConsultationName { get; set; }
    }
    public class ConsultationParams 
    {
        public Guid DoctorId { get; set; }
        public Guid PacientId { get; set; }
        public string ConsultationName { get; set; }
        public DateTime ConsultationDate { get; set; }
    }
   
    
}
