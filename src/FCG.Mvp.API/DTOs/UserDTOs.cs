namespace FCG.Mvp.API.DTOs
{
    public record RegisterRequest(string Name, string Email, string Password);
    public record LoginRequest(string Email, string Password);
    public record UserResponse(Guid Id, string Name, string Email, string Role);
}
