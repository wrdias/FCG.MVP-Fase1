using FCG.Mvp.API.Data;
using FCG.Mvp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FCG.Mvp.API.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _db;
        public GameService(AppDbContext db) => _db = db;

        public async Task<Game> CreateAsync(Game game)
        {
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
            return game;
        }

        public async Task<IEnumerable<Game>> ListAsync() => await _db.Games.ToListAsync();

        public async Task<Game?> GetAsync(Guid id) => await _db.Games.FindAsync(id);

        public async Task AcquireAsync(Guid userId, Guid gameId)
        {
            var exists = await _db.UserGames.FindAsync(userId, gameId);
            if (exists != null) return;
            var ug = new UserGame { UserId = userId, GameId = gameId, AcquiredAt = DateTime.UtcNow };
            _db.UserGames.Add(ug);
            await _db.SaveChangesAsync();
        }
    }
}
