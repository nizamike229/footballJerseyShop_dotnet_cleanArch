using Microsoft.EntityFrameworkCore;
using SneakerShop.Domain.Entities;
using SneakerShop.Domain.Repositories;

namespace SneakerShop.Infrastructure.Persistance;

public class JerseyRepository : IJerseyRepository
{
    private readonly JerseyDbContext _context;

    public JerseyRepository(JerseyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Jersey>> GetAllJerseys()
    {
        var jerseys = await _context.Jerseys.AsNoTracking().ToListAsync();
        foreach (var jersey in jerseys)
        {
            byte[] imageBytes = await File.ReadAllBytesAsync(jersey.Image);
            string base64String = Convert.ToBase64String(imageBytes);
            var fileExtension = Path.GetExtension(jersey.Image).ToLower().TrimStart('.');
            var mimeType = fileExtension switch
            {
                "jpg" or "jpeg" => "image/jpeg",
                "png" => "image/png",
                "gif" => "image/gif",
                "bmp" => "image/bmp",
                _ => "image/jpeg"
            };
            jersey.Image = $"data:{mimeType};base64,{base64String}";
        }

        return jerseys;
    }

    public async Task AddJersey(Jersey jersey)
    {
        var isExist = await _context.Jerseys.AnyAsync(s => s.Name == jersey.Name);
        if (isExist)
            throw new Exception("Jersey with this name already exists");

        await _context.Jerseys.AddAsync(jersey);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateJersey(Jersey jersey)
    {
        var current = await _context.Jerseys.FirstOrDefaultAsync(s => s.Id == jersey.Id);
        if (current == null)
        {
            throw new Exception("Jersey not found");
        }

        if (!string.IsNullOrWhiteSpace(current!.Name))
        {
            current.Name = jersey.Name;
        }

        if (!string.IsNullOrWhiteSpace(current!.Description))
        {
            current.Description = jersey.Description;
        }

        if (jersey.Price != current.Price)
        {
            current.Price = jersey.Price;
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteJersey(string jerseyId)
    {
        var jersey = _context.Jerseys.FirstOrDefault(s => s.Id == jerseyId);
        if (jersey == null)
        {
            throw new Exception("Jersey not found");
        }

        _context.Jerseys.Remove(jersey!);
        await _context.SaveChangesAsync();
    }
}