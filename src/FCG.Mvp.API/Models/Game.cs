using System.ComponentModel.DataAnnotations;

namespace FCG.Mvp.API.Models
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required] public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
