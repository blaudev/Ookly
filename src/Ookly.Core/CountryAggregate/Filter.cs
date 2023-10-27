namespace Ookly.Core.CountryAggregate;

public class Filter(string id) : Entity<string>(id)
{
    public List<Country> Countries { get; private set; } = [];
    public List<Category> Categories { get; private set; } = [];
    public List<CountryCategoryFilter> CountryCategoryFilter { get; private set; } = [];

    public void AddCategory(Category category)
    {
        if (Categories.Any(x => x.Id == category.Id))
        {
            return;
        }

        Categories.Add(category);
    }
}
