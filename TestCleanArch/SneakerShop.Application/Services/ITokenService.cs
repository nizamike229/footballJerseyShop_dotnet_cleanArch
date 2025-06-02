namespace SneakerShop.Application.Services;

public interface ITokenService
{
    string GenerateJwtToken(string username, string email, IEnumerable<string> roles);
}