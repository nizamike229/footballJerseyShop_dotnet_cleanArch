using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models.Requests;

public class UserRequest
{
    [MinLength(8)]
    [MaxLength(30)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string Username { get; set; }

    [MinLength(8)]
    [MaxLength(30)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Поле не может состоять только из пробелов")]
    public required string Password { get; set; }
}