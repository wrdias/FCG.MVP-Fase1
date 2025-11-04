namespace FCG.Mvp.API.Models
{
    public class UserGame
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;
        public DateTime AcquiredAt { get; set; } = DateTime.UtcNow;
    }
}
