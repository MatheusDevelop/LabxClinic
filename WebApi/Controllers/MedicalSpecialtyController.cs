using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/medical-specialties")]
    [ApiController]
    public class MedicalSpecialtyController : CrudController<MedicalSpecialty,MedicalSpecialtyInsertViewModel,IMedicalSpecialtyServices>
    {
        private readonly IMedicalSpecialtyServices _services;

        public MedicalSpecialtyController(IMedicalSpecialtyServices services):base(services)
        {
            _services = services;
        }
        [HttpGet]
        [Route("select")]
        public ActionResult<List<MedicalSpecialtySelectViewModel>> Select([FromQuery]FilterViewModel filter) 
       {
            try
            {
                List<MedicalSpecialtySelectViewModel> content = _services.Select(filter);
                return Ok(new {content,filter});

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
