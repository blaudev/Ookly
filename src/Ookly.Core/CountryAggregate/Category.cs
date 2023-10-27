using Ookly.Core.AdAggregate;

namespace Ookly.Core.CountryAggregate;

public class Category(string id) : Entity<string>(id), IAggregateRoot
{
    public List<Country> Countries { get; private set; } = default!;
    public List<Ad> Ads { get; private set; } = default!;
}
