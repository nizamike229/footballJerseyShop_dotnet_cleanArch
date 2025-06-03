using System.ComponentModel.DataAnnotations;

namespace SneakerShop.Domain.Entities;

public class Jersey
{
    [MaxLength(255)]
    public required string Id { get; set; }

    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public required string Description { get; set; }

    public required int Price { get; set; }
}
