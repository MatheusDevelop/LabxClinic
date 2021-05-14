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
    [Route("api/v1/clinics")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicServices _services;

        public ClinicController(IClinicServices services)
        {
            _services = services;
        }
        [HttpGet]
        public ActionResult<List<ClinicViewModel>> List([FromQuery]ClinicParams model,[FromQuery] FilterViewModel filter)
        {
            try
            {
                List<ClinicViewModel> content = _services.List(model,filter);
                return Ok(new { content, filter });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("select")]
        public ActionResult<List<ClinicSelectViewModel>> Select([FromQuery]FilterViewModel filter) 
       {
            try
            {
                List<ClinicSelectViewModel> content = _services.Select(filter);
                return Ok(new {content,filter});

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
