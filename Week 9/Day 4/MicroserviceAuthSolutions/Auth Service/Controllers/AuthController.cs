using Microsoft.AspNetCore.Mvc;
using Auth_Service.DTOs;
using Auth_Service.Services;

namespace Auth_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(dto);

            if (result.Message == "Email already registered.")
                return Conflict(result);

            return Ok(result);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authService.LoginAsync(dto);

            if (string.IsNullOrEmpty(result.Token))
                return Unauthorized(result);

            return Ok(result);
        }
    }
}
