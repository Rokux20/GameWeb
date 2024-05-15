using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface IGameRepository
    {
        Task<List<Game>> GetGames();
        Task<Game> GetGameId(int id);
        Task<Game> AddGame(string Partida, int UserId, int FarmId);
        Task<Game> UpdateGame(Game game);
        Task<Game> DeleteGame(int id);
    }
    public class GameRepository : IGameRepository
    {
        private readonly FarmDbContext _context;

        public GameRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetGames()
        {
            return await _context.Game.ToListAsync();
        }

        public async Task<Game> GetGameId(int id)
        {
            return await _context.Game.FindAsync(id);
        }

        public async Task<Game> AddGame(string Partida, int UserId, int FarmId)
        {
            var game = new Game
            {
                Partida = Partida,
                UserId = UserId,
                FarmId = FarmId
            };

            await _context.Game.AddAsync(game);
            _context.SaveChanges();
            return game;
        }

        public async Task<Game> UpdateGame(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> DeleteGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return null;
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return game;
        }
    }
}
