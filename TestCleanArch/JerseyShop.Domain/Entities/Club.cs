
namespace SneakerShop.Domain.Entities;

public class Club
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public virtual ICollection<Jersey> Jerseys { get; set; } = new List<Jersey>();
}
