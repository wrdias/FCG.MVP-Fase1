using FCG.Mvp.API.DTOs;
using FCG.Mvp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Mvp.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService) => _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var res = await _userService.RegisterAsync(req);
            return CreatedAtAction(null, res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var token = await _userService.AuthenticateAsync(req);
            if (token is null) return Unauthorized();
            return Ok(new { token });
        }
    }
}
