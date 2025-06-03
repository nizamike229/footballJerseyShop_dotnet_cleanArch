using Microsoft.EntityFrameworkCore;
using SneakerShop.Application.Services;
using SneakerShop.Domain.Entities;
using SneakerShop.Domain.Repositories;

namespace SneakerShop.Infrastructure.Persistance;

public class AuthRepository : IAuthRepository
{
    private readonly ITokenService _tokenService;
    private readonly JerseyDbContext _context;

    public AuthRepository(ITokenService tokenService, JerseyDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    public async Task<string> Register(User user)
    {
        var isUsernameFree = await _context.Users.AnyAsync(x => x.Username == user.Username);
        if (isUsernameFree)
            throw new Exception("Username is already taken");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return "User successfully registered";
    }

    public async Task<string> Login(User request)
    {
        var isUserExits = await _context.Users.AnyAsync(x => x.Username == request.Username);
        if (!isUserExits)
            throw new Exception("User not found!");
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);

        var isPasswordCorrect = BCrypt.Net.BCrypt.Verify(request.PasswordHash, user!.PasswordHash);
        if (!isPasswordCorrect)
            throw new Exception("Invalid password!");

        var token = _tokenService.GenerateJwtToken(user);
        return token;
    }
}