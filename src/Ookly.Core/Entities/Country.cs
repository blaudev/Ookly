namespace Ookly.Core.Entities;

public class Country(string id) : Entity<string>(id), IAggregateRoot
{
    public List<CountryCategory> CountryCategories { get; private set; } = [];

    public void AddCountryCategory(CountryCategory category)
    {
        CountryCategories.Add(category);
    }

}

public class CountryCategory(string countryId, string categoryId, int order) : Entity<string>($"{countryId}_{categoryId}")
{
    public CountryCategory(Country country, Category category, int order) : this(country.Id, category.Id, order)
    {
        Country = country;
        Category = category;
    }

    public string CountryId { get; private set; } = countryId;
    public Country Country { get; private set; } = default!;

    public string CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;

    public int Order { get; private set; } = order;

    public List<CategoryFilter> CategoryFilters { get; private set; } = [];

    public void AddCategoryFilter(CategoryFilter filter)
    {
        CategoryFilters.Add(filter);
    }
}

public class CategoryFilter(string countryCategoryId, string filterId) : Entity<string>($"{countryCategoryId}_{filterId}")
{
    public CategoryFilter(CountryCategory countryCategory, Filter filter) : this(countryCategory.Id, filter.Id)
    {
        CountryCategory = countryCategory;
        Filter = filter;
    }

    public string CountryCategoryId { get; private set; } = countryCategoryId;
    public CountryCategory CountryCategory { get; private set; } = default!;

    public string FilterId { get; private set; } = filterId;
    public Filter Filter { get; private set; } = default!;
}
