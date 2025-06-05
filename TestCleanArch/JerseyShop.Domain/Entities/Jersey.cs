namespace SneakerShop.Domain.Entities;

public class Jersey
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required int Price { get; set; }
    
    public required string ClubName { get; set; }
    public string Image { get; set; }
}
