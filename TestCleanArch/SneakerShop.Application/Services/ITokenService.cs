using SneakerShop.Domain.Entities;

namespace SneakerShop.Application.Services;

public interface ITokenService
{
    string GenerateJwtToken(User user);
}