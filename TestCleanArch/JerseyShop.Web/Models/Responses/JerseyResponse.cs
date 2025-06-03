using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models.Responses;

public class JerseyResponse
{
    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public required string Description { get; set; }

    public required int Price { get; set; }
}