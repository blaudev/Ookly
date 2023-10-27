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

    public void AddMeta(Category category, Filter filter)
    {
        category.AddFilter(filter);
        AddCategory(category);

        filter.AddCategory(category);
        AddFilter(filter);

        var data = new CountryCategoryFilter(this, category, filter);
        CountryCategoryFilter.Add(data);
    }
}
