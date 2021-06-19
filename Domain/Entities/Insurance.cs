using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Insurance:Entity
    {
        public Insurance(string picUrl, string planName, string holder, string walletNumber)
        {
            PicUrl = picUrl;
            PlanName = planName;
            Holder = holder;
            WalletNumber = walletNumber;
        }
        public ICollection<Pacient> Pacients { get; private set; }
        public ICollection<ExamCoverage> ExamsCoverages { get; private set; }
        public string PicUrl { get; private set; }
        public string PlanName { get; private set; }
        public string Holder { get; private set; }
        public string WalletNumber { get; private set; }
    }
}
