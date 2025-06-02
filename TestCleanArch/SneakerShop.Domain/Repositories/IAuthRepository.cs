using SneakerShop.Domain.Entities;

namespace SneakerShop.Domain.Repositories;

public interface IAuthRepository
{
    Task<string> Register(User user);
    Task<string> Login(User request);
}