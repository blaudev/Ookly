namespace Ookly.Core.CountryAggregate;

public class CountryCategoryFilter(string countryId, string categoryId, string filterId) : Entity<string>($"{countryId}_{categoryId}_{filterId}")
{
    public CountryCategoryFilter(Country country, Category category, Filter filter) : this(country.Id, category.Id, filter.Id)
    {
        Country = country;
        Category = category;
        Filter = filter;
    }

    public string CountryId { get; private set; } = countryId;
    public virtual Country Country { get; private set; } = default!;

    public string CategoryId { get; private set; } = categoryId;
    public virtual Category Category { get; private set; } = default!;

    public string FilterId { get; private set; } = filterId;
    public virtual Filter Filter { get; private set; } = default!;
}
