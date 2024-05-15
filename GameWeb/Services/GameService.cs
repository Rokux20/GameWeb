using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetGames();
        Task<Game> GetGameId(int id);
        Task<Game> AddGame(string Partida, int UserId, int FarmId);
        Task<Game> UpdateGame(int GameId, string? Partida = null, int? FamrId = null, int? UserId = null);
        Task<Game> DeleteGame(int id);
    }
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<Game>> GetGames()
        {
            return await _gameRepository.GetGames();
        }

        public async Task<Game> GetGameId(int id)
        {
            return await _gameRepository.GetGameId(id);
        }

        public async Task<Game> AddGame(string Partida, int UserId, int FarmId)
        {
            return await _gameRepository.AddGame(Partida, UserId, FarmId);
        }

        public async Task<Game> UpdateGame(int GameId, string? Partida = null, int? FarmId = null, int? UserId = null)
        {
            var game = await _gameRepository.GetGameId(GameId);
            if (game == null)
            {
                throw new Exception("Game not found");
            }

            if (Partida != null)
            {
                game.Partida = Partida;
            }
            if (FarmId != null)
            {
                game.FarmId = (int)FarmId;
            }
            if (UserId != null)
            {
                game.UserId = (int)UserId;
            }

            return await _gameRepository.UpdateGame(game);
        }
        public async Task<Game> DeleteGame(int id)
        {
            return await _gameRepository.DeleteGame(id);
        }
    }
}
