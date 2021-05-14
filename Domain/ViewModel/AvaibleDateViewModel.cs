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
}
