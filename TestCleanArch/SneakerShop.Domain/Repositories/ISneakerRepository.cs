using SneakerShop.Domain.Entities;

namespace SneakerShop.Domain.Repositories;

public interface ISneakerRepository
{ 
    Task<List<Sneaker>> GetAllSneakers();
    Task AddSneaker(Sneaker sneaker);
    Task UpdateSneaker(Sneaker sneaker);
    Task DeleteSneaker(string sneakerId);
}