using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models.Requests;

public class SneakerRequest
{
    [MaxLength(255)]
    [MinLength(8)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string Title { get; set; }

    [MaxLength(500)]
    [MinLength(8)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string Description { get; set; }

    public required int Price { get; set; }
}