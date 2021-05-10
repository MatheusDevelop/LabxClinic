using Shared.Domain.Entities;
using Shared.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Domain.Services
{
    public class BaseService:IBaseService
    {
        public List<string> ValidationMessages { get; set; }
        public bool Invalid { get => ValidationMessages.Count>0;}
        
    }
}
