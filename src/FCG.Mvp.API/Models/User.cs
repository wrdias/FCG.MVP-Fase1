using System.ComponentModel.DataAnnotations;
using System.Data;

namespace FCG.Mvp.API.Models
{
    public enum Role { User, Admin }
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required] public string Name { get; set; } = null!;
        [Required] public string Email { get; set; } = null!;
        [Required] public string PasswordHash { get; set; } = null!;
        public Role Role { get; set; } = Role.User;
        public List<UserGame> Library { get; set; } = new();
    }
}
