using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/v1/consultations")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationServices _services;
        public ConsultationController(IConsultationServices services)
        {
            _services = services;
        }
        [HttpGet]
        public ActionResult<List<ConsultationViewModel>> Get(
            [FromQuery]ConsultationParams param
            , [FromQuery]FilterViewModel filter)
        {
            try
            {
                return _services.List(param, filter);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ConsultationInsertViewModel model)
        {
            try
            {
                await _services.Insert(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Post(ConsultationInsertViewModel model,Guid id)
        {
            try
            {
                await _services.Update(model,id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Post(Guid id)
        {
            try
            {
                await _services.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
