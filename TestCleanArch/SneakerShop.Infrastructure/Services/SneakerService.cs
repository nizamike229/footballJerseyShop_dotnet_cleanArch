using SneakerShop.Application.Services;
using SneakerShop.Domain.Entities;
using SneakerShop.Domain.Repositories;

namespace SneakerShop.Infrastructure.Services;

public class SneakerService : ISneakerService
{
    private readonly ISneakerRepository _sneakerRepository;

    public SneakerService(ISneakerRepository sneakerRepository)
    {
        _sneakerRepository = sneakerRepository;
    }

    public async Task<List<Sneaker>> GetAllSneakers()
    {
        return await _sneakerRepository.GetAllSneakers();
    }

    public async Task<Sneaker> GetSneakerById(string sneakerId)
    {
        return (await _sneakerRepository.GetAllSneakers()).FirstOrDefault(s=>s.Id == sneakerId)!;
    }

    public async Task<string> CreateSneaker(Sneaker sneaker)
    {
        await _sneakerRepository.AddSneaker(sneaker);
        return "Sneaker created successfully";
    }

    public async Task<string> EditSneaker(Sneaker sneaker)
    {
        await _sneakerRepository.UpdateSneaker(sneaker);
        return "Sneaker edited successfully";
    }

    public async Task<string> DeleteSneaker(string sneakerId)
    {
        await _sneakerRepository.DeleteSneaker(sneakerId);
        return "Sneaker deleted successfully";
    }
}