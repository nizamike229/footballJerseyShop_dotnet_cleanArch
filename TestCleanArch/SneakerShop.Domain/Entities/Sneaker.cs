using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SneakerShop.Domain.Entities;

public class Sneaker
{
    [MaxLength(255)]
    public required string Id { get; set; }

    [MaxLength(255)]
    public required string Title { get; set; }

    [MaxLength(500)]
    public required string Description { get; set; }

    public required int Price { get; set; }
}
