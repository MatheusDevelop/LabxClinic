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
    [Route("api/v1/avaliations")]
    [ApiController]
    public class AvaliationController : CrudController<Avaliation, AvaliationInsertViewModel, IAvaliationServices>
    {
        public AvaliationController(IAvaliationServices services) : base(services)
        {
        }

        [HttpGet]
        public ActionResult<List<AvaliationListViewModel>> Get(
            [FromQuery] AvaliationParams param
            , [FromQuery] FilterViewModel filter)
        {
            try
            {
                var content  = _services.List(param, filter);
                return base.Ok(new { content = content.content, filter ,content.average});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
