using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class ExamCoverageInsertViewModel
    {
        public Guid InsuranceId { get; set; }
        public string Name { get; set; }
    }
    public class ExamCoverageParams 
    {
        public Guid PacientId { get; set; }
    }
    public class ExamCoverageListViewModel {
        public string Name { get; set; }
    }

}
