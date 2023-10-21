using Blau.Entities;

using Ookly.Core.AdAggregate;
using Ookly.Core.CountryAggregate;

namespace Ookly.Core.CategoryAggregate;

public class Category(string name) : Entity, IAggregateRoot
{
    public string Name { get; private set; } = name;

    public List<Country> Countries { get; private set; } = default!;
    public IReadOnlyList<Ad> Ads { get; private set; } = default!;

    public void AddCountry(Country country)
    {
        Countries.Add(country);
    }

    public void AddCountries(IEnumerable<Country> countries)
    {
        Countries.AddRange(countries);
    }
}
