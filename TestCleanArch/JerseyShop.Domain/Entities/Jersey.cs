
namespace SneakerShop.Domain.Entities;

public class Jersey
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required int Price { get; set; }

    public required string ClubId { get; set; }

    public virtual Club? Club { get; set; }
}
