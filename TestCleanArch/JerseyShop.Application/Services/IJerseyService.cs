using SneakerShop.Domain.Entities;

namespace SneakerShop.Application.Services;

public interface IJerseyService
{
    Task<List<Jersey>> GetAllJerseys();
    Task<Jersey> GetJerseyById(string jerseyId);
    Task<string> CreateJersey(Jersey jersey);
    Task<string> EditJersey(Jersey jersey);
    Task<string> DeleteJersey(string jerseyId);
}