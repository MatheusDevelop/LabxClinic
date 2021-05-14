using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IAvaibleDateServices
    {
        public Task Insert(AvaibleDateInsertViewModel model);
    }
}
