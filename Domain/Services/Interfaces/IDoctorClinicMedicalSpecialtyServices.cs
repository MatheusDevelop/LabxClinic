using Domain.Entities;
using Domain.ViewModel;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IDoctorClinicMedicalSpecialtyServices:ICrudServices<DoctorClinicMedicalSpecialty,DoctorClinicMedicalSpecialtyInsertViewModel>
    {
       
    }
}
