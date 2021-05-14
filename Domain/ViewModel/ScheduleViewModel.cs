using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class ScheduleInsertViewModel
    {
        public Guid ClinicId { get; set; }
        public Guid MedicalSpecialtyId { get; set; }

    }
    public class ScheduleParams 
    {
        public int Month { get; set; }
        public Guid ClinicId { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
    }
    public class ScheduleViewModel 
    {
        public ScheduleViewModel(Guid id, ICollection<DateTime> avaibleDates)
        {
            Id = id;
            AvaibleDates = avaibleDates;
        }

        public Guid Id { get; set; }
        public ICollection<DateTime> AvaibleDates { get; set; }
    }

}
