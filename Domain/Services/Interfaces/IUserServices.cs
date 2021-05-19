using Domain.ViewModel;
using Shared.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IUserServices:IBaseService
    {
        public Task Insert(UserInsertViewModel model);
        public string Login(UserLoginViewModel model);
    }
}
