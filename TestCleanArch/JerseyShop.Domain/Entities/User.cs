using System;
using System.Collections.Generic;

namespace SneakerShop.Domain.Entities;

public class User
{
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string Role { get; set; } = null!;
}
