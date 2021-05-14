using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/v1/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleServices _services;
        private readonly IAvaibleDateServices _avaibleDateServices;

        public ScheduleController(IScheduleServices services, IAvaibleDateServices avaibleDateServices)
        {
            _services = services;
            _avaibleDateServices = avaibleDateServices;
        }
        [HttpPost]
        [Route("avaible-days")]
        public async Task<IActionResult> AvaibleDayPost(AvaibleDateInsertViewModel model)
        {
            try
            {
                await _avaibleDateServices.Insert(model);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet]
        [Route("avaible-days")]
        public ActionResult<ScheduleViewModel> View([FromQuery] ScheduleParams model)
        {
            try
            {
                var content = _services.View(model);
                return Ok(new { content });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ScheduleInsertViewModel model)
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
        public async Task<IActionResult> Post(ScheduleInsertViewModel model,Guid id)
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
