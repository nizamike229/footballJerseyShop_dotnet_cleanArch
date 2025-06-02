using SneakerShop.Application.Services;
using SneakerShop.Domain.Entities;
using SneakerShop.Domain.Repositories;

namespace SneakerShop.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repo;

    public AuthService(IAuthRepository repo)
    {
        _repo = repo;
    }

    public Task<string> Login(User user)
    {
        return _repo.Login(user);
    }

    public Task<string> Register(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            throw new Exception("Username and/or password are required");

        if (user.Password.Length < 8 || user.Password.Length > 30)
            throw new Exception("Password must be between 8 and 30 characters");

        if (user.Username.Length < 8 || user.Username.Length > 30)
            throw new Exception("Username must be between 8 and 30 characters");

        return _repo.Register(user);
    }
}