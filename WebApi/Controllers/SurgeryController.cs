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
    [Route("api/v1/surgeries")]
    [ApiController]
    public class SurgeryController : CrudController<Surgery, SurgeryInsertViewModel, ISurgeryServices>
    {
        public SurgeryController(ISurgeryServices services) : base(services)
        {
        }
        
    }
}
