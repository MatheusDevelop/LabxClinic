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
    [Route("api/v1/clinics")]
    [ApiController]
    public class ClinicController : CrudController<Clinic,ClinicInsertViewModel,IClinicServices>
    {
        public ClinicController(IClinicServices services):base(services)
        {
        }
        [HttpGet]
        public ActionResult<List<ClinicViewModel>> List([FromQuery]ClinicParams model,[FromQuery] FilterViewModel filter)
        {
            try
            {
                var content = _services.List(model,filter);
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
