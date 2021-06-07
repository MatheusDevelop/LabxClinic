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
    [Route("api/v1/allergies")]
    [ApiController]
    public class AllergyController : CrudController<Allergy, AllergyInsertViewModel, IAllergyServices>
    {
        public AllergyController(IAllergyServices services) : base(services)
        {
        }
        
    }
}
