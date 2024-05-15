using GameWeb.Models;
using GameWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GameWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            return Ok(await _gameService.GetGames());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameId(int id)
        {
            var game = await _gameService.GetGameId(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame([FromBody] Game game)
        {
            return Ok(await _gameService.AddGame(game.Partida, game.UserId, game.FarmId));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> UpdateGame(int id, [FromBody] Game game)
        {
            try
            {
                return Ok(await _gameService.UpdateGame(id, game.Partida));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _gameService.DeleteGame(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }
    }
}
