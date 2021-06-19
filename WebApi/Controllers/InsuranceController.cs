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
    [Route("api/v1/insurances")]
    [ApiController]
    public class InsuranceController : CrudController<Insurance, InsuranceInsertViewModel, IInsuranceServices>
    {
        public InsuranceController(IInsuranceServices services) : base(services)
        {
        }
        [HttpGet]
        public ActionResult<InsuranceViewModel> GetWithPacientId(Guid pacientId)
        {
            try
            {
                return _services.GetWithPacientId(pacientId);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
