using FCG.Mvp.API.DTOs;
using Microsoft.AspNetCore.Identity.Data;

namespace FCG.Mvp.API.Services
{
    public interface IUserService
    {
        Task<UserResponse> RegisterAsync(DTOs.RegisterRequest req);
        Task<string?> AuthenticateAsync(DTOs.LoginRequest req);
    }
}
