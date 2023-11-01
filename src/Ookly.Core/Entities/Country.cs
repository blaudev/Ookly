namespace Ookly.Core.Entities;

public class Country(string id) : Entity<string>(id), IAggregateRoot
{
    public List<CountryCategory> Categories { get; private set; } = [];

    public void AddCategory(CountryCategory category)
    {
        Categories.Add(category);
    }

}

public class CountryCategory(string countryId, string categoryTypeId) : Entity<string>($"{countryId}_{categoryTypeId}")
{
    public CountryCategory(Country country, Category categoryType) : this(country.Id, categoryType.Id)
    {
        Country = country;
        CategoryType = categoryType;
    }

    public string CountryId { get; private set; } = countryId;
    public Country Country { get; private set; } = default!;

    public string CategoryTypeId { get; private set; } = categoryTypeId;
    public Category CategoryType { get; private set; } = default!;

    public List<CategoryFilter> Filters { get; private set; } = [];

    public void AddFilter(CategoryFilter filter)
    {
        Filters.Add(filter);
    }
}
