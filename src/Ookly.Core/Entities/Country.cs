namespace Ookly.Core.Entities;

public class Country(string id) : Entity<string>(id), IAggregateRoot
{
    public List<CountryCategory> CountryCategories { get; private set; } = [];

    public void AddCategory(CountryCategory category)
    {
        CountryCategories.Add(category);
    }

}

public class CountryCategory(string countryId, string categoryId) : Entity<string>($"{countryId}_{categoryId}")
{
    public CountryCategory(Country country, Category category) : this(country.Id, category.Id)
    {
        Country = country;
        Category = category;
    }

    public string CountryId { get; private set; } = countryId;
    public Country Country { get; private set; } = default!;

    public string CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;

    public List<CategoryFilter> Filters { get; private set; } = [];

    public void AddFilter(CategoryFilter filter)
    {
        Filters.Add(filter);
    }
}

public class CategoryFilter(string categoryId, string filterId) : Entity<string>($"{categoryId}_{filterId}")
{
    public CategoryFilter(CountryCategory category, Filter filter) : this(category.Id, filter.Id)
    {
        Category = category;
        Filter = filter;
    }

    public string CategoryId { get; private set; } = categoryId;
    public CountryCategory Category { get; private set; } = default!;

    public string FilterId { get; private set; } = filterId;
    public Filter Filter { get; private set; } = default!;
}
