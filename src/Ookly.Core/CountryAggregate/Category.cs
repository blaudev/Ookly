namespace Ookly.Core.CountryAggregate;

public class Category(string countryId, string categoryTypeId) : Entity<string>($"{countryId}_{categoryTypeId}")
{
    public Category(Country country, CategoryType categoryType) : this(country.Id, categoryType.Id)
    {
        Country = country;
        CategoryType = categoryType;
    }

    public string CountryId { get; private set; } = countryId;
    public Country Country { get; private set; } = default!;

    public string CategoryTypeId { get; private set; } = categoryTypeId;
    public CategoryType CategoryType { get; private set; } = default!;

    public List<Filter> Filters { get; private set; } = [];

    public void AddFilter(Filter filter)
    {
        Filters.Add(filter);
    }
}
