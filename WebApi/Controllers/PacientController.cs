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
    [Route("api/v1/pacients")]
    [ApiController]
    public class PacientController : CrudController<Pacient, PacientInsertViewModel, IPacientServices>
    {
        public PacientController(IPacientServices services) : base(services)
        {
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<PacientViewModel> View(Guid id)
        {
            return Ok(new { content = _services.View(id) });
        }
        
    }
}
