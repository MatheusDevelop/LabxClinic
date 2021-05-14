using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/medical-specialties")]
    [ApiController]
    public class MedicalSpecialtyController : ControllerBase
    {
        private readonly IMedicalSpecialtyServices _services;

        public MedicalSpecialtyController(IMedicalSpecialtyServices services)
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
