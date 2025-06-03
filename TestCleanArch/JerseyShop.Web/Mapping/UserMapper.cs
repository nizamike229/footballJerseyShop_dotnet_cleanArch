using SneakerShop.Domain.Entities;
using SneakerShop.Domain.Enums;
using SneakersShop.Models.Requests;

namespace SneakersShop.Mapping;

public static class UserMapper
{
    public static User ToUser(this UserRequest request)
    {
        return new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = request.Username,
            Password = request.Password,
            Role = Role.User
        };
    }
}