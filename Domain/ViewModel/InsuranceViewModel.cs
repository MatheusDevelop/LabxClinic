using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class InsuranceInsertViewModel
    {
        public string PicUrl { get; set; }
        public string PlanName { get; set; }
        public string Holder { get; set; }
        public string WalletNumber { get; set; }
    }
    public class InsuranceParams
    {
        public Guid PacientId { get; set; }
    }
    public class InsuranceViewModel 
    {
        public string PicUrl { get; set; }
        public string PlanName { get; set; }
        public string Holder { get; set; }
        public string WalletNumber { get; set; }
    }
}
