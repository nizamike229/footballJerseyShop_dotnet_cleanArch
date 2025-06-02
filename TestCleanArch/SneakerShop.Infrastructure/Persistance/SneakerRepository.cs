using Microsoft.EntityFrameworkCore;
using SneakerShop.Domain.Entities;
using SneakerShop.Domain.Repositories;

namespace SneakerShop.Infrastructure.Persistance;

public class SneakerRepository : ISneakerRepository
{
    private readonly SneakerDbContext _context;

    public SneakerRepository(SneakerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Sneaker>> GetAllSneakers() => await _context.Sneakers.AsNoTracking().ToListAsync();

    public async Task AddSneaker(Sneaker sneaker)
    {
        var isExist = await _context.Sneakers.FirstOrDefaultAsync(s => s.Title == sneaker.Title) == null;
        if (isExist)
            throw new Exception("Sneaker with this title already exists");

        await _context.Sneakers.AddAsync(sneaker);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSneaker(Sneaker sneaker)
    {
        var current = await _context.Sneakers.FirstOrDefaultAsync(s => s.Id == sneaker.Id);
        if (current == null)
        {
            throw new Exception("Sneaker not found");
        }

        if (!string.IsNullOrWhiteSpace(current!.Title))
        {
            current.Title = sneaker.Title;
        }

        if (!string.IsNullOrWhiteSpace(current!.Description))
        {
            current.Description = sneaker.Description;
        }

        if (sneaker.Price != current.Price)
        {
            current.Price = sneaker.Price;
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteSneaker(string sneakerId)
    {
        var sneaker = _context.Sneakers.FirstOrDefault(s => s.Id == sneakerId);
        if (sneaker == null)
        {
            throw new Exception("Sneaker not found");
        }

        _context.Sneakers.Remove(sneaker!);
        await _context.SaveChangesAsync();
    }
}