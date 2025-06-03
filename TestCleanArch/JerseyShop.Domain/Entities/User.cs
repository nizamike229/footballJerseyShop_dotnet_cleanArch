using System.ComponentModel.DataAnnotations;
using SneakerShop.Domain.Enums;

namespace SneakerShop.Domain.Entities;

public class User
{
    [MaxLength(255)]
    public required string Id { get; set; }
    
    [MaxLength(30)]
    [MinLength(8)]
    public required string Username { get; set; }
    
    [MaxLength(30)]
    [MinLength(8)]
    public required string Password { get; set; }
    
    [AllowedValues(0,1)]
    public Role Role { get; set; }
}