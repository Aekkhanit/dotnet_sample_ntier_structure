using BusUserServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IBusAUserServices _IBusAUserServices;
        public UserController(IBusAUserServices IBusAUserServices)
        {
            _IBusAUserServices = IBusAUserServices;
        }
        [HttpGet("info/{username}")]
        public async Task<IActionResult> GetUserInfo([FromRoute] string username = "uesr_a")
        {
            return Ok(await _IBusAUserServices.GenerateTokenAsync(username));
        }

    }
}
