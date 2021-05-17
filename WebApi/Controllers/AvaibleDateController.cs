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
    [Route("api/v1/available-dates")]
    [ApiController]
    public class AvaibleDateController : CrudController<AvailableDate, AvaibleDateInsertViewModel, IAvaibleDateServices>
    {
        public AvaibleDateController(IAvaibleDateServices services) : base(services)
        {
        }
        [HttpGet]
        public ActionResult<List<AvailableDateViewModel>> Get([FromQuery]AvailableDateParams model,[FromQuery]FilterViewModel filter)
        {
            try
            {
                var content = _services.List(model, filter);
                return Ok(new { content, filter });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
