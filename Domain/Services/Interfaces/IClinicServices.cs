﻿using Domain.ViewModel;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IClinicServices
    {
        public List<ClinicSelectViewModel> Select(FilterViewModel filter);
        public List<ClinicViewModel> List(ClinicParams model, FilterViewModel filter);
    }
}