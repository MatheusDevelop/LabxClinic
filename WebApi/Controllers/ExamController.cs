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
    [Route("api/v1/exams")]
    [ApiController]
    public class ExamController : CrudController<Exam, ExamInsertViewModel, IExamServices>
    {
        public ExamController(IExamServices services) : base(services)
        {
        }
        [HttpGet]
        public ActionResult<List<ExamViewModel>> List([FromQuery] ExamParams model, [FromQuery] FilterViewModel filter)
        {
            try
            {
                var content = _services.List(model, filter);
                return Ok(new { content = content.Item1, filter ,content.totalAvailableInDatabase,content.totalPendencyInDatabase});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
