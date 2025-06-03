using SneakerShop.Domain.Entities;

namespace SneakerShop.Domain.Repositories;

public interface IJerseyRepository
{ 
    Task<List<Jersey>> GetAllJerseys();
    Task AddJersey(Jersey jersey);
    Task UpdateJersey(Jersey jersey);
    Task DeleteJersey(string jerseyId);
}