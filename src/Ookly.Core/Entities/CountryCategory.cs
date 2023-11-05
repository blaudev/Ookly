using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Core.Entities;

public class CountryCategory : Entity
{
    public int CountryId { get; init; }
    public Country Country { get; init; } = new();

    public int CategoryId { get; init; }
    public Category Category { get; init; } = new();

    public int Order { get; init; }

    public List<Filter> Filters { get; init; } = [];
    public List<Listing> Listings { get; init; } = [];
}
