using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class AvaibleDateInsertViewModel
    {
        public Guid ScheduleId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
    public class AvailableDateParams 
    {
        public Guid ScheduleId { get; set; }
        public Guid ClinicId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
        public int Day { get; set; }
    }

    public class AvailableDateViewModel 
    {
        public Guid Id { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }
}
