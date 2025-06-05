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

    [Required]
    public required int Price { get; set; }
    
    [MaxLength(255)]
    [MinLength(1)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string ClubName { get; set; }

    [MinLength(10)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string Image { get; set; }
}