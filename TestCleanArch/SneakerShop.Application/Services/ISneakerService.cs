using SneakerShop.Domain.Entities;

namespace SneakerShop.Application.Services;

public interface ISneakerService
{
    Task<List<Sneaker>> GetAllSneakers();
    Task<Sneaker> GetSneakerById(string sneakerId);
    Task<string> CreateSneaker(Sneaker sneaker);
    Task<string> EditSneaker(Sneaker sneaker);
    Task<string> DeleteSneaker(string sneakerId);
}