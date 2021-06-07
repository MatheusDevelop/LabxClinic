using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class ExamInsertViewModel
    {
        public bool Pendency { get;  set; }
        public DateTime? PrevisionDate { get;  set; }
        public string Name { get;  set; }
        public string FileUrl { get;  set; }
        public string Description { get; set; }
        public Guid PacientId { get;  set; }
        public Guid DoctorId { get;  set; }
    }
    public class ExamParams 
    {
        public bool? UnvailableExams { get; set; }
        public Guid PacientId { get; set; }
        public Guid DoctorId { get; set; }
    }

    public class ExamViewModel 
    {
        public Guid Id { get; set; }
        public Guid PacientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Pendency { get; set; }
        public string DoctorName { get; set; }
        public string PacientName { get; set; }
        public string DoctorPicUrl { get; set; }
        public string PacientPicUrl { get; set; }
        public string FileUrl { get; set; }
        public string Name { get; set; }
        public DateTime PrevisionDate { get; set; }
    }

}
