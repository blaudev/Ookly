namespace Ookly.Core.Entities;

public class Category : NamedEntity
{
    public List<Filter> Filters { get; init; } = [];
    public List<CountryCategory> CountryCategories { get; init; } = [];
    //public List<ListingDetailType> ListingDetailTypes { get; init; } = [];
}
