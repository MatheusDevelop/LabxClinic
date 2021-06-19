using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class AvaliationListViewModel
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Note { get; set; }
    }
    public class AvaliationParams 
    {
        public Guid DoctorId { get; set; }
    }
    public class AvaliationInsertViewModel
    {
        public Guid DoctorId { get; set; }
        public string Comment { get; set; }
        public int Note { get; set; }
    }
}
