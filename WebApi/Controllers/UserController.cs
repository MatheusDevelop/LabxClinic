using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInsertViewModel model)
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
    }
}
