using FCG.Mvp.API.Models;

namespace FCG.Mvp.API.Services
{
    public interface IGameService
    {
        Task<Game> CreateAsync(Game game);
        Task<IEnumerable<Game>> ListAsync();
        Task<Game?> GetAsync(Guid id);
        Task AcquireAsync(Guid userId, Guid gameId);
    }
}
