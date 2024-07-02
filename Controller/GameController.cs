using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Entity;
using CarSales.Interfaces;
using Microsoft.Extensions.Logging;

namespace CarSales.Controllers // Ensure the namespace is correct
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GameController> _logger;

        public GameController(IGameService gameService, ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
        {
            _logger.LogInformation("Getting all games");
            var games = await _gameService.GetAllAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            _logger.LogInformation($"Getting game with ID: {id}");
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                _logger.LogWarning($"Game with ID: {id} not found");
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame([FromBody] Game game)
        {
            _logger.LogInformation($"Creating a new game with ID: {game.Id}");
            await _gameService.AddGameAsync(game);
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(Guid id, [FromBody] Game game)
        {
            if (id != game.Id)
            {
                _logger.LogWarning($"Update request with mismatched ID: {id}");
                return BadRequest();
            }

            _logger.LogInformation($"Updating game with ID: {game.Id}");
            await _gameService.UpdateGameAsync(game);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            _logger.LogInformation($"Deleting game with ID: {id}");
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                _logger.LogWarning($"Delete request for non-existing game ID: {id}");
                return NotFound();
            }

            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }
    }
}
