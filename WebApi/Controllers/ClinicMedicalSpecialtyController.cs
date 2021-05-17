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
    [Route("api/v1/clinic-medical-specialties")]
    [ApiController]
    public class ClinicMedicalSpecialtyController : CrudController<ClinicMedicalSpecialty,ClinicMedicalSpecialtyInsertViewModel, IClinicMedicalSpecialtyServices>
    {
        public ClinicMedicalSpecialtyController(IClinicMedicalSpecialtyServices services):base(services)
        {

        }
    }
}
