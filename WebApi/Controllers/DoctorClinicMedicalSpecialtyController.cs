using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/doctor-clinic-medical-specialties")]
    [ApiController]
    public class DoctorClinicMedicalSpecialtyController : CrudController<DoctorClinicMedicalSpecialty,DoctorClinicMedicalSpecialtyInsertViewModel, IDoctorClinicMedicalSpecialtyServices>
    {
        public DoctorClinicMedicalSpecialtyController(IDoctorClinicMedicalSpecialtyServices services):base(services)
        {

        }
    }
}
