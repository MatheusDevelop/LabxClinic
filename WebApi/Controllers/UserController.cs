using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("sing-up")]
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
        [HttpPost]
        [Route("login")]
        public ActionResult Login(UserLoginViewModel model)
        {
            try
            {
                var jwt = _services.Login(model);
                return Ok(new { jwt });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
