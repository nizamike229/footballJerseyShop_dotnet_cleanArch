using SneakerShop.Domain.Entities;

namespace SneakerShop.Application.Services;

public interface IAuthService
{
    Task<string> Login(User user);
    Task<string> Register(User user);
}