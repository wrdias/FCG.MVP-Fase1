using FCG.Mvp.API.Models;
using FCG.Mvp.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Mvp.API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService) => _gameService = gameService;

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            var g = await _gameService.CreateAsync(game);
            return CreatedAtAction(nameof(Get), new { id = g.Id }, g);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List() => Ok(await _gameService.ListAsync());

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id) => Ok(await _gameService.GetAsync(id));

        [HttpPost("{id:guid}/acquire")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Acquire(Guid id)
        {
            var userId = Guid.Parse(User.FindFirst("id")!.Value);
            await _gameService.AcquireAsync(userId, id);
            return NoContent();
        }
    }
}
