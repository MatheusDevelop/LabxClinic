using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    public class CrudController<TEntity, InsertViewModel,Service>: ControllerBase where TEntity : Entity where Service : ICrudServices<TEntity, InsertViewModel>
    {
        public readonly Service _services;

        public CrudController(Service services)
        {
            _services = services;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(InsertViewModel model)
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
        public async Task<IActionResult> Post(InsertViewModel model, Guid id)
        {
            try
            {
                await _services.Update(model, id);
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
