using SneakerShop.Domain.Entities;
using SneakersShop.Models.Requests;
using SneakersShop.Models.Responses;

namespace SneakersShop.Mapping;

public static class JerseyMapper
{
    public static Jersey ToJersey(this JerseyRequest jerseyRequest)
    {
        return new Jersey
        {
            Id = Guid.NewGuid().ToString(),
            Name = jerseyRequest.Name,
            Description = jerseyRequest.Description,
            Price = jerseyRequest.Price,
        };
    }

    public static JerseyResponse ToJerseyResponse(this Jersey jersey)
    {
        return new JerseyResponse
        {
            Name = jersey.Name,
            Description = jersey.Description,
            Price = jersey.Price,
        };
    }

    public static List<JerseyResponse> ToJerseyResponseList(this List<Jersey> jerseys)
    {
        return jerseys.Select(jersey => jersey.ToJerseyResponse()).ToList();
    }
}