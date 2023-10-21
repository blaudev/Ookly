using Ookly.Core.AdAggregate;

namespace Ookly.Core.CountryAggregate;

public class Category(Guid id, string name) : Entity(id), IAggregateRoot
{
    public string Name { get; private set; } = name;

    public List<Country> Countries { get; private set; } = default!;
    public List<Ad> Ads { get; private set; } = default!;
}
