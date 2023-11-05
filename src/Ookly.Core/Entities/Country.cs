using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Core.Entities;

public class Country : NamedEntity, IAggregateRoot
{
    public List<CountryCategory> CountryCategories { get; init; } = [];
    public List<Listing> Listings { get; init; } = [];
}
