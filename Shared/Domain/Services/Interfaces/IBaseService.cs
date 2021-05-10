using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Domain.Services.Interfaces
{
    public interface IBaseService
    {
        List<string> ValidationMessages { get; set; }
        bool Invalid { get; }

    }
}
