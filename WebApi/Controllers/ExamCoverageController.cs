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
    [Route("api/v1/exams-coverages")]
    [ApiController]
    public class ExamCoverageController : CrudController<ExamCoverage, ExamCoverageInsertViewModel, IExamCoverageServices>
    {
        public ExamCoverageController(IExamCoverageServices services) : base(services)
        {
        }
        [HttpGet]
        public ActionResult<List<ExamCoverageListViewModel>> List([FromQuery] ExamCoverageParams model, [FromQuery] FilterViewModel filter)
        {
            try
            {
                return Ok(new { content = _services.List(model, filter), filter });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
