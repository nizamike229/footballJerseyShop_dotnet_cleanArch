using SneakerShop.Domain.Entities;
using SneakersShop.Models.Requests;
using SneakersShop.Models.Responses;

namespace SneakersShop.Mapping;

public static class SneakerMapper
{
    public static Sneaker ToSneaker(this SneakerRequest sneakerRequest)
    {
        return new Sneaker
        {
            Id = Guid.NewGuid().ToString(),
            Title = sneakerRequest.Title,
            Description = sneakerRequest.Description,
            Price = sneakerRequest.Price,
        };
    }

    public static SneakerResponse ToSneakerResponse(this Sneaker sneaker)
    {
        return new SneakerResponse
        {
            Title = sneaker.Title,
            Description = sneaker.Description,
            Price = sneaker.Price,
        };
    }

    public static List<SneakerResponse> ToSneakerResponseList(this List<Sneaker> sneakers)
    {
        return sneakers.Select(sneaker => sneaker.ToSneakerResponse()).ToList();
    }
}