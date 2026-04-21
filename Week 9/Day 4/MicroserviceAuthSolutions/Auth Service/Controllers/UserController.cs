using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("profile")]
        [Authorize]
        public IActionResult GetProfile()
        {
            return Ok("Access granted. This is protected data.");
        }
    }
}
