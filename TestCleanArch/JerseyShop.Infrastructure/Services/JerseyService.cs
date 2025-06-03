using SneakerShop.Application.Services;
using SneakerShop.Domain.Entities;
using SneakerShop.Domain.Repositories;

namespace SneakerShop.Infrastructure.Services;

public class JerseyService : IJerseyService
{
    private readonly IJerseyRepository _jerseyRepository;

    public JerseyService(IJerseyRepository jerseyRepository)
    {
        _jerseyRepository = jerseyRepository;
    }

    public async Task<List<Jersey>> GetAllJerseys()
    {
        return await _jerseyRepository.GetAllJerseys();
    }

    public async Task<Jersey> GetJerseyById(string jerseyId)
    {
        return (await _jerseyRepository.GetAllJerseys()).FirstOrDefault(s=>s.Id == jerseyId)!;
    }

    public async Task<string> CreateJersey(Jersey jersey)
    {
        await _jerseyRepository.AddJersey(jersey);
        return "Jersey created successfully";
    }

    public async Task<string> EditJersey(Jersey jersey)
    {
        await _jerseyRepository.UpdateJersey(jersey);
        return "Jersey edited successfully";
    }

    public async Task<string> DeleteJersey(string jerseyId)
    {
        await _jerseyRepository.DeleteJersey(jerseyId);
        return "Jersey deleted successfully";
    }
}