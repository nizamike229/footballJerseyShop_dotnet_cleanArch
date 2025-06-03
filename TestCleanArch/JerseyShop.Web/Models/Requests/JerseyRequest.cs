using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models.Requests;

public class JerseyRequest
{
    [MaxLength(255)]
    [MinLength(3)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string Name { get; set; }

    [MaxLength(500)]
    [MinLength(8)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string Description { get; set; }

    public required int Price { get; set; }
    public required string ClubId { get; set; }
}