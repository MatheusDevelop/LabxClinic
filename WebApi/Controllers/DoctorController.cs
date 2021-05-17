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
    [Route("api/v1/doctors")]
    [ApiController]
    public class DoctorController : CrudController<Doctor, DoctorInsertViewModel, IDoctorServices>
    {
        public DoctorController(IDoctorServices services) : base(services)
        {
        }
        [HttpGet]
        [Route("select")]
        public ActionResult<DoctorSelectViewModel> Select([FromQuery] FilterViewModel model)
        {
            try
            {
                List<DoctorSelectViewModel> content = _services.Select(model);
                return Ok(new { content, model });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult<DoctorViewModel> List([FromQuery]DoctorParams model,[FromQuery] FilterViewModel filter)
        {
            try
            {
                List<DoctorViewModel> content = _services.List(model,filter);
                return Ok(new { content, model });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
