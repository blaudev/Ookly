namespace Ookly.Core.CountryAggregate;

public class Country(string id) : Entity<string>(id), IAggregateRoot
{
    public List<Category> Categories { get; private set; } = [];
    public List<Filter> Filters { get; private set; } = [];
    public List<CountryCategoryFilter> CountryCategoryFilter { get; private set; } = [];

    private void AddCategory(Category category)
    {
        if (Categories.Any(x => x.Id == category.Id))
        {
            return;
        }

        Categories.Add(category);
    }

    private void AddFilter(Filter filter)
    {
        if (Filters.Any(x => x.Id == filter.Id))
        {
            return;
        }

        Filters.Add(filter);
    }

    public void AddCategoryFilter(CountryCategoryFilter data)
    {
        data.Category.AddFilter(data.Filter);
        data.Filter.AddCategory(data.Category);

        AddCategory(data.Category);
        AddFilter(data.Filter);

        CountryCategoryFilter.Add(data);
    }
}
